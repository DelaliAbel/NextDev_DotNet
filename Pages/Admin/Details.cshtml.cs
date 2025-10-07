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
    public class DetailsModel : PageModel
    {
        private readonly NextDev_DotNet.Data.AppDbContext _context;

        public DetailsModel(NextDev_DotNet.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
