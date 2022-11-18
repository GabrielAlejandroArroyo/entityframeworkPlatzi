using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace entityframeworkPlatzi.Migrations
{
    public partial class InitialData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "TareaId", "Titulo" },
                values: new object[] { new Guid("097d60ad-b300-4cbf-8283-7f7df5c61001"), null, new DateTime(2022, 11, 18, 20, 6, 35, 281, DateTimeKind.Local).AddTicks(9713), 1, new Guid("097d60ad-b300-4cbf-8283-7f7df5c61003"), "Pago de servicios publicos" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "CategoriaId", "Descripcion", "FechaCreacion", "PrioridadTarea", "TareaId", "Titulo" },
                values: new object[] { new Guid("097d60ad-b300-4cbf-8283-7f7df5c61002"), null, new DateTime(2022, 11, 18, 20, 6, 35, 281, DateTimeKind.Local).AddTicks(9727), 0, new Guid("097d60ad-b300-4cbf-8283-7f7df5c61004"), "Terminar de ver pelicula en Netflix" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "CategoriaId",
                keyValue: new Guid("097d60ad-b300-4cbf-8283-7f7df5c61001"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "CategoriaId",
                keyValue: new Guid("097d60ad-b300-4cbf-8283-7f7df5c61002"));
        }
    }
}
