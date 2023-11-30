using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPass1.Migrations
{
    public partial class M02_FlyerEvento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "flyer",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flyer",
                table: "Eventos");
        }
    }
}
