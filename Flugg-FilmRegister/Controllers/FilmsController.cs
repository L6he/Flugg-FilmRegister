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
using System.IO;

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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null) { return NotFound(); }

            var film = await _filmsServices.DetailsAsync(id);

            if (film == null) { NotFound(); }

            //var images = await _context.FilesToDatabase
            //                           .Where(x => x.FilmID == id)
            //                           .Select(y => new FilmImageViewModel
            //                           {
            //                               FilmID = y.ID,

            //                               ImageID = y.ID,

            //                               ImageData = y.ImageData,

            //                               ImageTitle = y.ImageTitle,
            //                               //😢😢😢😢😢😢😢😢😢😢😢😢😢😢
            //                               Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //                           }).ToArrayAsync();

            var vm = new FilmDeleteViewModel();

            vm.ID = film.ID;

            vm.FilmName = film.FilmName;
    
            vm.Description = film.Description;

            vm.ReleaseDate = film.ReleaseDate;

            vm.Genre = film.Genre;

            vm.Director = film.Director;

            vm.Language = film.Language;

            //vm.Image.AddRange(images);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var filmToDelete = await _filmsServices.Delete(id);

            if (filmToDelete == null) { return RedirectToAction("Index"); }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id /*, Guid ref*/)
        {
            var film = await _filmsServices.DetailsAsync(id);

            if (film == null) { return NotFound(); }

            //var images = await _context.FilesToDatabase
            //    .Where(p => p.FilmID == id)
            //    .Select(y => new FilmImageViewModel
            //    {
            //        FilmID = y.ID,
            //        ImageID = y.ID,
            //        ImageData = y.ImageData,
            //        ImageTitle = y.ImageTitle,
            //        Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
            //    }).ToArrayAsync();

            var vm = new FilmDetailsViewModel();
            vm.ID = film.ID;
            vm.FilmName = film.FilmName;
            vm.Description = film.Description;
            vm.ReleaseDate = film.ReleaseDate;
            vm.Genre = film.Genre;
            vm.Director = film.Director;
            vm.Language = film.Language;
            //vm.Image.AddRange(images);

            return View(vm);
        }

        public async Task<IActionResult> Clone(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var film = await _context.Films.FirstOrDefaultAsync(m => m.ID == id);

            var cloneFilm = new Film
            {
                FilmName = film.FilmName,
                Description = film.Description,
                ReleaseDate = film.ReleaseDate,
                Genre = film.Genre,
                Director = film.Director,
                Language = film.Language,
            };

            if (film == null)
            {
                return NotFound();
            }

            if (cloneFilm != null)
            {
                _context.Films.Add(cloneFilm);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index"); //no way it finally works
        }
    }
}
