namespace Flugg_FilmRegister.Models.Films
{
    //public enum Genre
    //{
    //    Adventure,
    //    Animation,
    //    Biography,
    //    Comedy,
    //    Crime,
    //    Documentary,
    //    Drama,
    //    Family,
    //    Fantasy,
    //    History,
    //    Horror,
    //    Music,
    //    Musical,
    //    Mystery,
    //    Romance,
    //    SciFi,
    //    Sport,
    //    Thriller,
    //    War,
    //    Western,
    //    Superhero,
    //    Noir,
    //    Disaster,
    //    Experimental
    //}
    public class FilmCreateViewModel
    {
        public Guid ID { get; set; }
        public string? FilmName { get; set; }
        public string? Description { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public string? Director { get; set; }
        public string? Language { get; set; }

        //public List<IFormFile> Files { get; set; }
        //public List<FilmImageViewModel> Image { get; set; } = new List<FilmImageViewModel>();
    }
}
