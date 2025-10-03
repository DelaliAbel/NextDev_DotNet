using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextDev_DotNet.Migrations
{
    /// <inheritdoc />
    public partial class initialDBPropertyTeamMemberUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberImage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.MemberID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMember");
        }
    }
}
