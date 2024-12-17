using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyRazorProject.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

// {
//   "ConnectionStrings": {
//   "DefaultConnection": "Server=LAPTOP-6DA74A8K\\SQLEXPRESS;Database=MyWeb2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
// },
//   "Logging": {
//     "LogLevel": {
//       "Default": "Information",
//       "Microsoft.AspNetCore": "Warning"
//     }
//   },
//   "AllowedHosts": "*"
// }