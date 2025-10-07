using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class EditModel : PageModel
    {
        private readonly NextDev_DotNet.Data.AppDbContext _context;

        public EditModel(NextDev_DotNet.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TeamMember TeamMember { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teammember =  await _context.TeamMember.FirstOrDefaultAsync(m => m.MemberID == id);

            if (teammember == null)
            {
                return NotFound();
            }

            TeamMember = teammember;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Gestion de l'upload d'image
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine("wwwroot", "images");
                Directory.CreateDirectory(uploadsFolder);
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }
                TeamMember.MemberImage = "/images/" + uniqueFileName;
            }
            // Attacher et marquer TeamMember comme modifié dans tous les cas
            _context.Attach(TeamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(TeamMember.MemberID))
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

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMember.Any(e => e.MemberID == id);
        }
    }
}
