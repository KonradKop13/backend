using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Razor.Services;
using System.Threading.Tasks;

namespace Presentation.Razor.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly BookSoapClient _bookSoapClient;
        [BindProperty]
        public BookViewModel Book { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public CreateModel(BookSoapClient bookSoapClient)
        {
            _bookSoapClient = bookSoapClient;
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
                await _bookSoapClient.AddBookAsync(Book.Title, Book.Author, Book.Year);
                return RedirectToPage("Index");
            }
            catch (System.Exception ex)
            {
                ErrorMessage = ex.Message;
                return Page();
            }
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
