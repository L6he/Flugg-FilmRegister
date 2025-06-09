using Flugg_FilmRegister.Core.Dto;
using Flugg_FilmRegister.Core.Domain;

namespace Flugg_FilmRegister.Core.ServiceInterface
{
    public interface IFilmsServices
    {
        Task<Film> DetailsAsync(Guid id);

        Task<Film> Create(FilmDto dto);

        Task<Film> Update(FilmDto dto);

        Task<Film> Delete(Guid id);
    }
}
