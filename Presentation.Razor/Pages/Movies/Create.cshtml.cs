using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Razor.Models;
using Presentation.Razor.Services;
using System.Threading.Tasks;

namespace Presentation.Razor.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieSoapClient _movieSoapClient;
        [BindProperty]
        public MovieViewModel Movie { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public CreateModel(MovieSoapClient movieSoapClient)
        {
            _movieSoapClient = movieSoapClient;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            try
            {
                await _movieSoapClient.AddMovieAsync(Movie.Title, Movie.Director, Movie.Year);
                return RedirectToPage("Index");
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
}
