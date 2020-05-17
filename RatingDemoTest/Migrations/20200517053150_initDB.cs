using Microsoft.EntityFrameworkCore.Migrations;

namespace RatingDemoTest.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginServices",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginServiceId = table.Column<int>(nullable: false),
                    LoginServicePassCode = table.Column<string>(nullable: true),
                    IsStillLogin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginServices", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "ServicesRating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RatedServiceId = table.Column<int>(nullable: false),
                    RatedServicePoint = table.Column<int>(nullable: false),
                    RatedServiceComment = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesRating", x => x.RatingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginServices");

            migrationBuilder.DropTable(
                name: "ServicesRating");
        }
    }
}
