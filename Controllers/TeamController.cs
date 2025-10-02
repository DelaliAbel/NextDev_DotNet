using Microsoft.AspNetCore.Mvc;
using NextDev_DotNet.Models;

namespace NextDev_DotNet.Controllers
{
    public class TeamController : Controller
    {
        public IEnumerable<TeamMember> TeamMembers { get; set; }

        public TeamController()
        {
            TeamMembers = new List<TeamMember>
            {
                new TeamMember
                {
                    MemberID = 1,
                    MemberFullName = "JEFFREY BROWN",
                    MemberTitle = "Creative Leader",
                    MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    MemberPhone = "+227 00 00 00 00",
                    MemberEmail = "info@jeffreybrown.com",
                    MemberAddress = "Boukoki - Niamey, Niger",
                    MemberImage = "images/img_1.png"
                },
                new TeamMember
                {
                    MemberID = 2,
                    MemberFullName = "ALEX GREENFIELD",
                    MemberTitle = "Senior Developer",
                    MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    MemberPhone = "555-5678",
                    MemberEmail = "Soni - Niamey, Niger",
                    MemberImage = "images/img_2.png"
                },
                new TeamMember
                {
                    MemberID = 3,
                    MemberFullName = "LINDA LARSON",
                    MemberTitle = "UX Designer",
                    MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    MemberPhone = "555-8765",
                    MemberEmail = "Kalley-Est - Niamey, Niger",
                    MemberImage = "images/img_3.png"

                },
                new TeamMember
                {
                    MemberID = 4,
                    MemberFullName = "ANN RICHMOND",
                    MemberTitle = "QA Engineer",
                    MemberDescription = "Adipiscing elit, sed do eiusmod tempor incididunt ut labore",
                    MemberPhone = "555-4321",
                    MemberEmail = "Lazaré - Niamey, Niger",
                    MemberImage = "images/img_4.png"
                }
            };
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
