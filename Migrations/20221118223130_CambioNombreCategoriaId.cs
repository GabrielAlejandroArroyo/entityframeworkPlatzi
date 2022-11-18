using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframeworkPlatzi.Migrations
{
    public partial class CambioNombreCategoriaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CetegoriaId",
                table: "Categoria",
                newName: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categoria",
                newName: "CetegoriaId");
        }
    }
}
