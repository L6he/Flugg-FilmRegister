using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Flugg_FilmRegister.ApplicationServices.Services;
using Flugg_FilmRegister.Core.Domain;
using Flugg_FilmRegister.Core.Dto;
using Flugg_FilmRegister.Core.ServiceInterface;
using Flugg_FilmRegister.Data;
using Flugg_FilmRegister.Models.Films;
using System.Security.Cryptography.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace Flugg_FilmRegister.Controllers
{
    public class FilmsController : Controller
    {
        private readonly Flugg_FilmRegisterContext _context;
        private readonly IFilmsServices _filmsServices;
        //private readonly IFileServices _fileServices;

        public FilmsController(Flugg_FilmRegisterContext context, IFilmsServices filmsServices/*, IFileServices fileServices*/)
        {
            _context = context;
            _filmsServices = filmsServices;
            //_fileServices = fileServices;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Films
                .OrderByDescending(y => y.ID)
                .Select(x => new FilmIndexViewModel
                {
                    ID = x.ID,

                    FilmName = x.FilmName,

                    Description = x.Description,

                    ReleaseDate = x.ReleaseDate,

                    Genre = x.Genre,

                    Director = x.Director,

                    Language = x.Language,
                }
                );
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            FilmCreateViewModel vm = new();
            return View("Create", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmCreateViewModel vm)
        {
            var dto = new FilmDto()
            {
                FilmName = vm.FilmName,

                Description = vm.Description,

                ReleaseDate = vm.ReleaseDate,

                Genre = vm.Genre,

                Director = vm.Director,

                Language = vm.Language,

                //Files = vm.Files,

                //Image = vm.Image.Select(x => new FileToDatabaseDto
                //{
                //    ID = x.ImageID,
                //    ImageData = x.ImageData,
                //    ImageTitle = x.ImageTitle,
                //    FilmID = x.FilmID,
                //}
                //).ToArray()
            };
            var result = await _filmsServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", vm);
        }
    }
}
