namespace Flugg_FilmRegister.Models.Films
{

    public class FilmIndexViewModel
    {
        public Guid ID { get; set; }
        public string? FilmName { get; set; }
        public string? Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public string? Director { get; set; }
        public string? Language { get; set; }
    }
}
