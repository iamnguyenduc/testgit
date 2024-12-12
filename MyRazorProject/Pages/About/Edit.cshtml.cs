using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRazorProject.Data;
using MyRazorProject.Models;

namespace MyRazorProject.Pages_About
{
    public class EditModel : PageModel
    {
        private readonly MyRazorProject.Data.ApplicationDbContext _context;

        public EditModel(MyRazorProject.Data.ApplicationDbContext context)
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

            var aboutmodel =  await _context.AboutList.FirstOrDefaultAsync(m => m.Id == id);
            if (aboutmodel == null)
            {
                return NotFound();
            }
            AboutModel = aboutmodel;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AboutModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AboutModelExists(AboutModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AboutModelExists(int id)
        {
            return _context.AboutList.Any(e => e.Id == id);
        }
    }
}
