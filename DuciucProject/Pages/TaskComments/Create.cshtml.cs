using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DuciucProject.Models;

namespace DuciucProject.Pages.TaskComments
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
        ViewData["Item"] = new SelectList(_context.Items, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public TaskComment TaskComment { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            TaskComment.AddedDate = DateTime.UtcNow;

            _context.TaskComments.Add(TaskComment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
