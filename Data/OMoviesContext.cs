
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OMovies.Models;

namespace OMovies.Data
{
    public class OMoviesContext : IdentityDbContext<IdentityUser>
    {
        public OMoviesContext(DbContextOptions<OMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; } = default!;
    }
}
