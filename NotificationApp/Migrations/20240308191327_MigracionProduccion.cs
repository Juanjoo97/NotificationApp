using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NotificationApp.Migrations
{
    /// <inheritdoc />
    public partial class MigracionProduccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Referencia = table.Column<int>(type: "int", nullable: false),
                    Operario = table.Column<string>(type: "nvarchar(max)", nullable: true), // Permitir valores nulos
                    CantidadBuenas = table.Column<int>(type: "int", nullable: true), // Permitir valores nulos
                    CantidadMalas = table.Column<int>(type: "int", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GastosAdicionales = table.Column<int>(type: "int", nullable: true), // Permitir valores nulos
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true) // Permitir valores nulos
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produccion", x => x.Id);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produccion");
        }
    }
}
