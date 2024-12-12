using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyRazorProject.Data;
using MyRazorProject.Models;

namespace MyRazorProject.Pages_About
{
    public class CreateModel : PageModel
    {
        private readonly MyRazorProject.Data.ApplicationDbContext _context;

        public CreateModel(MyRazorProject.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AboutModel AboutModel { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kiểm tra nếu đã có profile tồn tại
            var existingProfile = _context.AboutList.FirstOrDefault();

            if (existingProfile != null)
            {
                // Xóa profile cũ
                _context.AboutList.Remove(existingProfile);
                await _context.SaveChangesAsync();
            }

            // Thêm profile mới
            _context.AboutList.Add(AboutModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        // public async Task<IActionResult> OnPostAsync()
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return Page();
        //     }

        //     _context.AboutList.Add(AboutModel);
        //     await _context.SaveChangesAsync();

        //     return RedirectToPage("./Index");
        // }
    }
}
