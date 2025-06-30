using System.ComponentModel.DataAnnotations;

namespace Presentation.Razor.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Director { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
    }
}
