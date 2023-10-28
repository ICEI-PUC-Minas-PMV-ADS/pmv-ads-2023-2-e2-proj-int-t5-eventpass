using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPass1.Migrations
{
    public partial class L01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evento_Usuario_GestorId",
                table: "Evento");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Evento_EventoIdEvento",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Evento_IdEvento",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Usuario_IdUsuario",
                table: "Ingresso");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingresso_Usuario_UsuarioId",
                table: "Ingresso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingresso",
                table: "Ingresso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Evento",
                table: "Evento");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Ingresso",
                newName: "Ingressos");

            migrationBuilder.RenameTable(
                name: "Evento",
                newName: "Eventos");

            migrationBuilder.RenameIndex(
                name: "IX_Ingresso_UsuarioId",
                table: "Ingressos",
                newName: "IX_Ingressos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingresso_IdUsuario",
                table: "Ingressos",
                newName: "IX_Ingressos_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Ingresso_IdEvento",
                table: "Ingressos",
                newName: "IX_Ingressos_IdEvento");

            migrationBuilder.RenameIndex(
                name: "IX_Ingresso_EventoIdEvento",
                table: "Ingressos",
                newName: "IX_Ingressos_EventoIdEvento");

            migrationBuilder.RenameIndex(
                name: "IX_Evento_GestorId",
                table: "Eventos",
                newName: "IX_Eventos_GestorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingressos",
                table: "Ingressos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos",
                column: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_GestorId",
                table: "Eventos",
                column: "GestorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Eventos_EventoIdEvento",
                table: "Ingressos",
                column: "EventoIdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Eventos_IdEvento",
                table: "Ingressos",
                column: "IdEvento",
                principalTable: "Eventos",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Usuarios_IdUsuario",
                table: "Ingressos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_GestorId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Eventos_EventoIdEvento",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Eventos_IdEvento",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Usuarios_IdUsuario",
                table: "Ingressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingressos_Usuarios_UsuarioId",
                table: "Ingressos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingressos",
                table: "Ingressos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Eventos",
                table: "Eventos");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Ingressos",
                newName: "Ingresso");

            migrationBuilder.RenameTable(
                name: "Eventos",
                newName: "Evento");

            migrationBuilder.RenameIndex(
                name: "IX_Ingressos_UsuarioId",
                table: "Ingresso",
                newName: "IX_Ingresso_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingressos_IdUsuario",
                table: "Ingresso",
                newName: "IX_Ingresso_IdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_Ingressos_IdEvento",
                table: "Ingresso",
                newName: "IX_Ingresso_IdEvento");

            migrationBuilder.RenameIndex(
                name: "IX_Ingressos_EventoIdEvento",
                table: "Ingresso",
                newName: "IX_Ingresso_EventoIdEvento");

            migrationBuilder.RenameIndex(
                name: "IX_Eventos_GestorId",
                table: "Evento",
                newName: "IX_Evento_GestorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingresso",
                table: "Ingresso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Evento",
                table: "Evento",
                column: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Evento_Usuario_GestorId",
                table: "Evento",
                column: "GestorId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Evento_EventoIdEvento",
                table: "Ingresso",
                column: "EventoIdEvento",
                principalTable: "Evento",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Evento_IdEvento",
                table: "Ingresso",
                column: "IdEvento",
                principalTable: "Evento",
                principalColumn: "IdEvento");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Usuario_IdUsuario",
                table: "Ingresso",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingresso_Usuario_UsuarioId",
                table: "Ingresso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
