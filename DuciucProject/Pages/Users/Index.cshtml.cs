using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DuciucProject.Models;

namespace DuciucProject.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly DuciucProject.Models.ProjectDbContext _context;

        public IndexModel(DuciucProject.Models.ProjectDbContext context)
        {
            _context = context;
        }

        public new IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.Users.ToListAsync();
        }
    }
}
