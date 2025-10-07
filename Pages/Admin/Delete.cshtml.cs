using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NextDev_DotNet.Data;
using NextDev_DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextDev_DotNet.Pages.Admin
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly NextDev_DotNet.Data.AppDbContext _context;

        public DeleteModel(NextDev_DotNet.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamMember TeamMember { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember = await _context.TeamMember.FirstOrDefaultAsync(m => m.MemberID == id);

            if (teammember == null)
            {
                return NotFound();
            }
            else
            {
                TeamMember = teammember;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember = await _context.TeamMember.FindAsync(id);
            if (teammember != null)
            {
                TeamMember = teammember;
                _context.TeamMember.Remove(TeamMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
