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
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Message = "Username and password are required.";
                return Page();
            }

            // Admin credentials
            if (username == "student@admin.com" && password == "Student@123")
            {
                // Set session for admin user
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("Username", username);
                return RedirectToPage("/Admin/Dashboard");
            }

            // For other users (clinician/patient)
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // TODO: Implement clinician/patient authentication
                return RedirectToPage("/Index");
            }

            Message = "Invalid username or password.";
            return Page();
        }
    }
}

