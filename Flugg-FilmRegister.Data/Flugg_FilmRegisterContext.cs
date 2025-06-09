using Flugg_FilmRegister.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Flugg_FilmRegister.Data
{
    public class Flugg_FilmRegisterContext : IdentityDbContext<ApplicationUser>
    {
        public Flugg_FilmRegisterContext(DbContextOptions<Flugg_FilmRegisterContext> options) : base(options) { }
        public DbSet<Film> Films { get; set; }

        public DbSet<FileToDatabase> FilesToDatabase { get; set; }

        public DbSet<IdentityRole> IdentityRoles { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
