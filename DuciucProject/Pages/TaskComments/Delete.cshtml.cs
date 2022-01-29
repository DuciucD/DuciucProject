using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DuciucProject.Models;

namespace DuciucProject.Pages.TaskComments
{
    public class DeleteModel : PageModel
    {
        private readonly DuciucProject.Models.ProjectDbContext _context;

        public DeleteModel(DuciucProject.Models.ProjectDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TaskComment TaskComment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TaskComment = await _context.TaskComments
                .Include(t => t.Item).FirstOrDefaultAsync(m => m.Id == id);

            if (TaskComment == null)
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

            TaskComment = await _context.TaskComments.FindAsync(id);

            if (TaskComment != null)
            {
                _context.TaskComments.Remove(TaskComment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
