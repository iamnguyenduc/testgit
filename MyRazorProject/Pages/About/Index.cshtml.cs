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
        private readonly MyRazorProject.Data.ApplicationDbContext _context;

        public IndexModel(MyRazorProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AboutModel> AboutModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AboutModel = await _context.AboutList.ToListAsync();
        }
    }
}
