using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoArellano.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class primeras_tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Letra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acordes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Generos_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LinksCanciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksCanciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinksCanciones_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_CancionId",
                table: "Artistas",
                column: "CancionId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_CancionId",
                table: "Generos",
                column: "CancionId");

            migrationBuilder.CreateIndex(
                name: "IX_LinksCanciones_CancionId",
                table: "LinksCanciones",
                column: "CancionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "LinksCanciones");

            migrationBuilder.DropTable(
                name: "Canciones");
        }
    }
}
