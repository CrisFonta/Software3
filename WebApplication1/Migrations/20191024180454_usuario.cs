using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreDueño",
                table: "Establecimientos");

            migrationBuilder.AddColumn<int>(
                name: "IdDueño",
                table: "Establecimientos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    UsuarioLogin = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Establecimientos_IdDueño",
                table: "Establecimientos",
                column: "IdDueño");

            migrationBuilder.AddForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueño",
                table: "Establecimientos",
                column: "IdDueño",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Establecimientos_Usuarios_IdDueño",
                table: "Establecimientos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Establecimientos_IdDueño",
                table: "Establecimientos");

            migrationBuilder.DropColumn(
                name: "IdDueño",
                table: "Establecimientos");

            migrationBuilder.AddColumn<string>(
                name: "NombreDueño",
                table: "Establecimientos",
                nullable: true);
        }
    }
}
