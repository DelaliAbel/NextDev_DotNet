using System.ComponentModel.DataAnnotations;

namespace NextDev_DotNet.Models
{
    public class TeamMember
    {
        [Key]
        public int MemberID { get; set; }
        public string MemberFullName { get; set; }
        public string MemberTitle { get; set; }
        public string MemberDescription { get; set; }
        public string MemberPhone { get; set; }
        public string MemberEmail { get; set; }
        public string MemberAddress { get; set; }
        public string MemberImage { get; set; }
    }
}
