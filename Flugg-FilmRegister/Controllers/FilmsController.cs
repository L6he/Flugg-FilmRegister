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
    }
}
