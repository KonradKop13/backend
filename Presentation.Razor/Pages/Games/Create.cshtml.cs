using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Razor.Services;
using System.Threading.Tasks;

namespace Presentation.Razor.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly GameSoapClient _gameSoapClient;
        [BindProperty]
        public GameViewModel Game { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public CreateModel(GameSoapClient gameSoapClient)
        {
            _gameSoapClient = gameSoapClient;
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
                await _gameSoapClient.AddGameAsync(Game.Title, Game.Developer, Game.Year);
                return RedirectToPage("Index");
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
    public class GameViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Developer { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
