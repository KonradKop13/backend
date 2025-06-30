using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Presentation.Razor.Services;

namespace Presentation.Razor.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly GameSoapClient _gameSoapClient;
        public List<Game> Games { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public IndexModel(GameSoapClient gameSoapClient)
        {
            _gameSoapClient = gameSoapClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Games = await _gameSoapClient.GetAllGamesAsync();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
