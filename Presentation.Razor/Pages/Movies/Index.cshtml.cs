using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Presentation.Razor.Services;

namespace Presentation.Razor.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieSoapClient _movieSoapClient;
        public List<Movie> Movies { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public IndexModel(MovieSoapClient movieSoapClient)
        {
            _movieSoapClient = movieSoapClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Movies = await _movieSoapClient.GetAllMoviesAsync();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
