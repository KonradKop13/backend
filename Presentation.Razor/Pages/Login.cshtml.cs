using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Presentation.Razor.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;
        [BindProperty]
        public string Role { get; set; } = "User";
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
            // If not logged in, prefill admin for demo
            if (!User.Identity.IsAuthenticated)
            {
                Username = "admin";
                Password = "admin";
                Role = "Admin";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Only allow login for default admin
            if (Username == "admin" && Password == "admin")
            {
                Role = "Admin";
            }
            else
            {
                ErrorMessage = "Invalid username or password.";
                return Page();
            }
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Role, Role)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToPage("/Index");
        }
    }
}
