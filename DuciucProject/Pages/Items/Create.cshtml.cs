using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DuciucProject.Models;

namespace DuciucProject.Pages.Items
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
        ViewData["Milestone"] = new SelectList(_context.Milestones, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Item Item { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Milestone"] = new SelectList(_context.Milestones, "Id", "Name");
                return Page();
            }

            _context.Items.Add(Item);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
