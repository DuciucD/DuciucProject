using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuciucProject.Models;

namespace DuciucProject.Pages.TaskComments
{
    public class EditModel : PageModel
    {
        private readonly DuciucProject.Models.ProjectDbContext _context;

        public EditModel(DuciucProject.Models.ProjectDbContext context)
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
            ViewData["Item"] = new SelectList(_context.Items, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TaskComment.UpdatedDate = DateTime.UtcNow;

            _context.Attach(TaskComment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskCommentExists(TaskComment.Id))
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

        private bool TaskCommentExists(int id)
        {
            return _context.TaskComments.Any(e => e.Id == id);
        }
    }
}
