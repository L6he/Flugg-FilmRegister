using Microsoft.AspNetCore.Http;

namespace Flugg_FilmRegister.Core.Dto
{
    public class FilmDto
    {
        public Guid ID { get; set; }
        public string? FilmName { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
