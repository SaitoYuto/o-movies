using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OMovies.Models;

public class Movie
{
    public int Id { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string? Title { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [DataType(DataType.Currency)]
    [Range(1, 100)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [Required]
    [StringLength(30)]
    public string? Genre { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    [Required]
    [StringLength(5)]
    public string Rating { get; set; } = string.Empty;

    [StringLength(100)]
    public string? Director { get; set; }

    [Display(Name = "Main Cast")]
    [StringLength(200)]
    public string? MainCast { get; set; }

    [DataType(DataType.MultilineText)]
    [StringLength(1000)]
    public string? Synopsis { get; set; }

    [Display(Name = "Poster Image")]
    [Url]
    [StringLength(2083)]
    [RegularExpression(@"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$")]
    public string? PosterImageUrl { get; set; } = "https://movieposter.blob.core.windows.net/poster/default.jpeg";

    [NotMapped]
    [Display(Name = "Poster Image File")]
    public IFormFile? PosterImageFile { get; set; }
}
