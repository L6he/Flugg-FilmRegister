using Microsoft.AspNetCore.Http;

namespace Flugg_FilmRegister.Core.Dto
{
    public class FilmDto
    {
        public Guid ID { get; set; }
        public string? FilmName { get; set; }
        public string? Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public string? Director { get; set; }
        public string? Language { get; set; }

        //public List<IFormFile> Files { get; set; }
        //public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();
    }
}
