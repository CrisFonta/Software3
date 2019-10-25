using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class usuario2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueño",
                table: "Establecimientos");

            migrationBuilder.RenameColumn(
                name: "IdDueño",
                table: "Establecimientos",
                newName: "IdDueno");

            migrationBuilder.RenameIndex(
                name: "IX_Establecimientos_IdDueño",
                table: "Establecimientos",
                newName: "IX_Establecimientos_IdDueno");

            migrationBuilder.AddForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueno",
                table: "Establecimientos",
                column: "IdDueno",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueno",
                table: "Establecimientos");

            migrationBuilder.RenameColumn(
                name: "IdDueno",
                table: "Establecimientos",
                newName: "IdDueño");

            migrationBuilder.RenameIndex(
                name: "IX_Establecimientos_IdDueno",
                table: "Establecimientos",
                newName: "IX_Establecimientos_IdDueño");

            migrationBuilder.AddForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueño",
                table: "Establecimientos",
                column: "IdDueño",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
