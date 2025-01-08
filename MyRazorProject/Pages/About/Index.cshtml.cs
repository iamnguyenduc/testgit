using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorProject.Data;
using MyRazorProject.Models;

namespace MyRazorProject.Pages_About
{
  public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IndexModel(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public IList<AboutModel> AboutModel { get; set; } = default!;

    // Add a public property or method to expose session data
    public bool IsLoggedIn => !string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Session.GetString("Username"));


    public async Task OnGetAsync()
    {
        AboutModel = await _context.AboutList.ToListAsync();
    }
}


}
