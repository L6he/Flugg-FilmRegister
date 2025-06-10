using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Genre
{
    Adventure,
    Animation,
    Biography,
    Comedy,
    Crime,
    Documentary,
    Drama,
    Family,
    Fantasy,
    History,
    Horror,
    Music,
    Musical,
    Mystery,
    Romance,
    SciFi,
    Sport,
    Thriller,
    War,
    Western,
    Superhero,
    Noir,
    Disaster,
    Experimental
}
namespace Flugg_FilmRegister.Core.Domain
{
    public class Film
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
