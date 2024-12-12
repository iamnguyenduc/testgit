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
    public class DeleteModel : PageModel
    {
        private readonly MyRazorProject.Data.ApplicationDbContext _context;

        public DeleteModel(MyRazorProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AboutModel AboutModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutmodel = await _context.AboutList.FirstOrDefaultAsync(m => m.Id == id);

            if (aboutmodel is not null)
            {
                AboutModel = aboutmodel;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aboutmodel = await _context.AboutList.FindAsync(id);
            if (aboutmodel != null)
            {
                AboutModel = aboutmodel;
                _context.AboutList.Remove(AboutModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
