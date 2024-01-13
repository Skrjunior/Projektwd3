using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektWD3.Models;

namespace ProjektWD3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProjektWD3.Models.Hry> Hry { get; set; } = default!;
        public DbSet<ProjektWD3.Models.Anime_Filmy_a_Seriály> Anime_Filmy_a_Seriály { get; set; } = default!;
    }
}