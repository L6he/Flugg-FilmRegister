using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flugg_FilmRegister.Core.Domain
{
    public class Film
    {
        public Guid ID { get; set; } 
        public string? FilmName { get; set; }
    }
}
