using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextDev_DotNet.Data;
using NextDev_DotNet.Models;

namespace NextDev_DotNet.Controllers
{
    
    public class TeamController : Controller
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }
        private AppDbContext _appDbContext;

        public TeamController(AppDbContext i_appDbContext)
        {
            _appDbContext = i_appDbContext;

            //Verifier si la base de données contient déjà des membres d'équipe
            if (_appDbContext.TeamMember.Any())
            {
                TeamMembers = _appDbContext.TeamMember.ToList();
                return;
            }
            else
            {
                TeamMembers = new List<TeamMember>
                {
                    new TeamMember
                    {
                        MemberFullName = "JEFFREY BROWN",
                        MemberTitle = "Creative Leader",
                        MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                        MemberPhone = "+227 00 00 00 00",
                        MemberEmail = "info@jeffreybrown.com",
                        MemberAddress = "Boukoki - Niamey, Niger",
                        MemberImage = "/images/img_1.png"
                    },
                    new TeamMember
                    {
                        MemberFullName = "ALEX GREENFIELD",
                        MemberTitle = "Senior Developer",
                        MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                        MemberPhone = "555-5678",
                        MemberEmail = "info@alexgreenfield.com",
                        MemberAddress = "Soni - Niamey, Niger",
                        MemberImage = "/images/img_2.png"
                    },
                    new TeamMember
                    {
                        MemberFullName = "LINDA LARSON",
                        MemberTitle = "UX Designer",
                        MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                        MemberPhone = "555-8765",
                        MemberEmail = "info@lindalarson.com",
                        MemberAddress = "Kalley-Est - Niamey, Niger",
                        MemberImage = "/images/img_3.png"

                    },
                    new TeamMember
                    {
                        MemberFullName = "ANN RICHMOND",
                        MemberTitle = "QA Engineer",
                        MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                        MemberPhone = "555-4321",
                        MemberEmail = "inf@annrichmond",
                        MemberAddress = "Lazaré - Niamey, Niger",
                        MemberImage = "/images/img_4.png"
                    }
                };

                foreach (var member in TeamMembers)
                {
                    _appDbContext.TeamMember.AddRange(member);
                }
                _appDbContext.SaveChanges();
            }
        }

        public IActionResult Index()
        {

            return View(TeamMembers);
        }

        public IActionResult Detail(int id)
        {
            var member = TeamMembers.FirstOrDefault(m => m.MemberID == id);
            if (member == null) return NotFound();

            return View(member);
        }
    }
}
