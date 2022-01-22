using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DuciucProject.Models;

namespace DuciucProject.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly DuciucProject.Models.ProjectDbContext _context;

        public CreateModel(DuciucProject.Models.ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["User"] = new SelectList(_context.Users, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
