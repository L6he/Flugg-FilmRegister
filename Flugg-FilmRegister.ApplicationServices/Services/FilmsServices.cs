using Microsoft.EntityFrameworkCore;
using Flugg_FilmRegister.Core.Domain;
using Flugg_FilmRegister.Core.Dto;
using Flugg_FilmRegister.Core.ServiceInterface;
using Flugg_FilmRegister.Data;

namespace Flugg_FilmRegister.ApplicationServices.Services
{
    public class FilmsServices : IFilmsServices
    {
        private readonly Flugg_FilmRegisterContext _context;
        //private readonly IFileServices _fileServices;

        public FilmsServices(Flugg_FilmRegisterContext context /*, IFileServices fileServices*/)
        {
            _context = context;
            //_fileServices = fileServices;
        }

        public async Task<Film> DetailsAsync(Guid id)
        {
            var result = await _context.Films
                .FirstOrDefaultAsync(x => x.ID == id);
            return result;
        }

        public async Task<Film> Create(FilmDto dto)
        {
            Film film = new();
            //set by saavis
            film.FilmName = dto.FilmName;
            film.ID = Guid.NewGuid();
            film.Description = dto.Description;
            film.ReleaseDate = dto.ReleaseDate;
            film.Genre = dto.Genre;
            film.Director = dto.Director;
            film.Language = dto.Language;


            //fairusu
            //if (dto.Files != null)
            //{
            //    _fileServices.UploadFilesToDb(dto, film);
            //}

            await _context.Films.AddAsync(film);
            await _context.SaveChangesAsync();

            return film;
        }

        public async Task<Film> Update(FilmDto dto)
        {
            Film film = new();
            //set by saavis
            film.ID = Guid.NewGuid();
            film.FilmName = dto.FilmName;
            film.Description = dto.Description;
            film.ReleaseDate = dto.ReleaseDate;
            film.Genre = dto.Genre;
            film.Director = dto.Director;
            film.Language = dto.Language;

            //fairusu
            //if (dto.Files != null)
            //{
            //    _fileServices.UploadFilesToDb(dto, film);
            //}
            _context.Films.Update(film);
            await _context.SaveChangesAsync();

            return film;
        }

        public async Task<Film> Delete(Guid id)
        {
            var result = await _context.Films
                .FirstOrDefaultAsync(x => x.ID == id);
            _context.Films.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
