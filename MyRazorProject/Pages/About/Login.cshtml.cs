using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http; // Add this for IHttpContextAccessor
using MyRazorProject.Data;
using MyRazorProject.Models;

namespace MyRazorProject.Pages_About
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // Inject IHttpContextAccessor
        public LoginModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // Handle GET request
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        // Handle POST request
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check user credentials in the database
            var user = _context.AboutList.FirstOrDefault(u => u.Name == Username && u.Phone == Password);

            if (user != null)
            {
                // Login successful
                _httpContextAccessor.HttpContext.Session.SetString("Username", Username);  // Store username in session
                return RedirectToPage("./Index");
            }

            // Login failed
            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return Page();
        }
    }
}
