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
    public class IndexModel : PageModel
    {
        private readonly NextDev_DotNet.Data.AppDbContext _context;

        public IndexModel(NextDev_DotNet.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<TeamMember> TeamMember { get;set; } = default!;

        public async Task OnGetAsync()
        {
            TeamMember = await _context.TeamMember.ToListAsync();
        }
    }
}
