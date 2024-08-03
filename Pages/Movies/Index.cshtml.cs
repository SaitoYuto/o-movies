using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OMovies.Data;
using OMovies.Utilities;
using OMovies.Models;

namespace OMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly OMoviesContext _context;

        public IndexModel(OMoviesContext context)
        {
            _context = context;
        }

        public PaginatedList<Movie> Movie { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? PageNumber { get; set; }

        public async Task OnGetAsync()
        {
            var moviesQuery = CreateMoviesQuery();
            moviesQuery = ApplyFilters(moviesQuery);
            moviesQuery = ApplySorting(moviesQuery);
            Genres = await GetGenresAsync();
            Movie = await GetPaginatedResultsAsync(moviesQuery);
        }

        private IQueryable<Movie> CreateMoviesQuery()
        {
            return from m in _context.Movie select m;
        }

        private IQueryable<Movie> ApplyFilters(IQueryable<Movie> query)
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                query = query.Where(s => s.Title.Contains(SearchString)
                    || s.Director.Contains(SearchString)
                    || s.MainCast.Contains(SearchString)
                    || s.Synopsis.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                query = query.Where(x => x.Genre == MovieGenre);
            }

            return query;
        }

        private IQueryable<Movie> ApplySorting(IQueryable<Movie> query)
        {
            return SortOrder switch
            {
                "title_desc" => query.OrderByDescending(m => m.Title),
                "date" => query.OrderBy(m => m.ReleaseDate),
                "date_desc" => query.OrderByDescending(m => m.ReleaseDate),
                _ => query.OrderBy(m => m.Title),
            };
        }
        private async Task<SelectList> GetGenresAsync()
        {
            var genres = await _context.Movie
                .Select(m => m.Genre)
                .Distinct()
                .OrderBy(g => g)
                .ToListAsync();

            return new SelectList(genres);
        }

        private async Task<PaginatedList<Movie>> GetPaginatedResultsAsync(IQueryable<Movie> query)
        {
            return await PaginatedList<Movie>.CreateAsync(query.AsNoTracking(), PageNumber ?? 1, 10);
        }
    }
}
