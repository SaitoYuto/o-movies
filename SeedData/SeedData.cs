using Microsoft.EntityFrameworkCore;
using OMovies.Data;

namespace OMovies.SeedData;

public static class SeedData
{
    public static async void InitializeAsync(IServiceProvider serviceProvider)
    {
        using (var context = new OMoviesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<OMoviesContext>>()))
        {
            if (context == null || context.Movie == null)
            {
                throw new ArgumentNullException("Null OMoviesContext");
            }

            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }

            await AddMoviesAsync(context);
        }
    }
    private static async Task AddMoviesAsync(OMoviesContext context)
    {
        await context.Movie.AddRangeAsync(MovieData.GetMovies());
        await context.SaveChangesAsync();
    }
}