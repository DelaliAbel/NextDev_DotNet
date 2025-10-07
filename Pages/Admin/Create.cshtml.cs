using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NextDev_DotNet.Data;
using NextDev_DotNet.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace NextDev_DotNet.Pages.Admin
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly NextDev_DotNet.Data.AppDbContext _context;

        public CreateModel(NextDev_DotNet.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TeamMember TeamMember { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }

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
            else
            {
                return Page();
            }

            _context.TeamMember.Add(TeamMember);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
