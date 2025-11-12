using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        public string? Message { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost(string username, string password, bool rememberMe)
        {
            // TODO: Implement actual authentication logic here
            // For now, this is a placeholder
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Message = "Username and password are required.";
                return Page();
            }

            // Simple example: accept any non-empty credentials
            // In production, validate against a database with hashed passwords
            if (username == "admin" && password == "password")
            {
                // TODO: Set authentication cookie or token
                return RedirectToPage("/Index");
            }

            Message = "Invalid username or password.";
            return Page();
        }
    }
}
