using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        public string AdminName { get; set; } = "";
        public List<AdminUser> Admins { get; set; } = new();
        public List<Clinician> Clinicians { get; set; } = new();
        public List<Patient> Patients { get; set; } = new();

        public void OnGet()
        {
            // Check if user is authenticated as admin
            var userRole = HttpContext.Session.GetString("UserRole");
            var username = HttpContext.Session.GetString("Username");

            if (userRole != "Admin")
            {
                Response.Redirect("/login");
                return;
            }

            AdminName = username ?? "Admin";

            // Load sample data (in production, this would come from a database)
            LoadSampleData();
        }

        public IActionResult OnPostAddClinician(string name, string email, string specialization, string password)
        {
            // Check authentication
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToPage("/login");
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(specialization) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return Page();
            }

            // TODO: Save to database
            // For now, just redirect back to dashboard
            return RedirectToPage("/Admin/Dashboard");
        }

        public IActionResult OnPostAddPatient(string name, string email, int age, string password)
        {
            // Check authentication
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToPage("/login");
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || 
                age <= 0 || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return Page();
            }

            // TODO: Save to database
            // For now, just redirect back to dashboard
            return RedirectToPage("/Admin/Dashboard");
        }

        public IActionResult OnPostAssignAdmin(string name, string email, string roleType, string password)
        {
            // Check authentication
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToPage("/login");
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || 
                string.IsNullOrWhiteSpace(roleType) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return Page();
            }

            // TODO: Save admin user to database
            // For now, just redirect back to dashboard
            return RedirectToPage("/Admin/Dashboard");
        }

        private void LoadSampleData()
        {
            // Sample admins
            Admins = new List<AdminUser>
            {
                new AdminUser { Id = "A001", Name = "John Admin", Email = "john.admin@admin.com", RoleType = "Super Admin" },
                new AdminUser { Id = "A002", Name = "Sarah Manager", Email = "sarah.manager@admin.com", RoleType = "User Manager" }
            };

            // Sample clinicians
            Clinicians = new List<Clinician>
            {
                new Clinician { Id = "C001", Name = "Dr. John Smith", Email = "john.smith@clinic.com", Specialization = "Cardiology" },
                new Clinician { Id = "C002", Name = "Dr. Sarah Johnson", Email = "sarah.johnson@clinic.com", Specialization = "Neurology" },
                new Clinician { Id = "C003", Name = "Dr. Mike Williams", Email = "mike.williams@clinic.com", Specialization = "Orthopedics" }
            };

            // Sample patients
            Patients = new List<Patient>
            {
                new Patient { Id = "P001", Name = "Alice Brown", Email = "alice.brown@patient.com", Age = 28 },
                new Patient { Id = "P002", Name = "Bob Davis", Email = "bob.davis@patient.com", Age = 35 },
                new Patient { Id = "P003", Name = "Carol White", Email = "carol.white@patient.com", Age = 42 }
            };
        }
    }

    public class Clinician
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Specialization { get; set; } = "";
    }

    public class Patient
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public int Age { get; set; }
    }

    public class AdminUser
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string RoleType { get; set; } = "";
    }
}
