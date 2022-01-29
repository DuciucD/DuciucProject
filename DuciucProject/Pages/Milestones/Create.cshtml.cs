using DuciucProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace DuciucProject.Pages.Milestones
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
            ViewData["Project"] = new SelectList(_context.Projects, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Milestone Milestone { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Milestones.Add(Milestone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
