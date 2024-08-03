
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OMovies.Data;
using OMovies.Models;
using OMovies.Services;

namespace OMovies.Pages.Movies
{

    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly OMoviesContext _context;

        private readonly AzureBlobService _blobService;

        public CreateModel(OMoviesContext context, AzureBlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Movie.PosterImageFile != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Movie.PosterImageFile.FileName);
                using var stream = Movie.PosterImageFile.OpenReadStream();
                Movie.PosterImageUrl = await _blobService.UploadImageAsync(stream, fileName);
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
