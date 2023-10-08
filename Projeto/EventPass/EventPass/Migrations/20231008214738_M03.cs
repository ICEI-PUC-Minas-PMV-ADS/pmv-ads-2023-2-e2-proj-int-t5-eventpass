using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPass.Migrations
{
    public partial class M03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CPFouCNPJ",
                table: "Usuarios",
                newName: "CPF");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Usuarios",
                newName: "CPFouCNPJ");

            migrationBuilder.AddColumn<int>(
                name: "Tipo",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
