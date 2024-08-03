using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OMovies.Data;
using OMovies.Models;
using OMovies.Services;

namespace OMovies.Pages.Movies
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly OMoviesContext _context;

        private readonly AzureBlobService _blobService;


        public EditModel(OMoviesContext context, AzureBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            Movie = movie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                if (Movie.PosterImageFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Movie.PosterImageFile.FileName);
                    using var stream = Movie.PosterImageFile.OpenReadStream();
                    Movie.PosterImageUrl = await _blobService.UploadImageAsync(stream, fileName);
                }
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
