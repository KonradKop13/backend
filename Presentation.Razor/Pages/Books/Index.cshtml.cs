using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Presentation.Razor.Services;

namespace Presentation.Razor.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookSoapClient _bookSoapClient;
        public List<Book> Books { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public IndexModel(BookSoapClient bookSoapClient)
        {
            _bookSoapClient = bookSoapClient;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Books = await _bookSoapClient.GetAllBooksAsync();
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
