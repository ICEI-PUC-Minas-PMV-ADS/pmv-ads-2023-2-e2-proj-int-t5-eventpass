using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPass1.Migrations
{
    public partial class M08_Update_Model_ingresso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ingressos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Ingressos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
