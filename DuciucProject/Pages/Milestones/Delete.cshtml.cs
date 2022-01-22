using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DuciucProject.Models;

namespace DuciucProject.Pages.Milestones
{
    public class DeleteModel : PageModel
    {
        private readonly DuciucProject.Models.ProjectDbContext _context;

        public DeleteModel(DuciucProject.Models.ProjectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Milestone Milestone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Milestone = await _context.Milestones
                .Include(m => m.Project).FirstOrDefaultAsync(m => m.Id == id);

            if (Milestone == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Milestone = await _context.Milestones.FindAsync(id);

            if (Milestone != null)
            {
                _context.Milestones.Remove(Milestone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
