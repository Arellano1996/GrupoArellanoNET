using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrupoArellano.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class corregir_relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Artistas_Canciones_CancionId",
                table: "Artistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Generos_Canciones_CancionId",
                table: "Generos");

            migrationBuilder.DropForeignKey(
                name: "FK_LinksCanciones_Canciones_CancionId",
                table: "LinksCanciones");

            migrationBuilder.DropIndex(
                name: "IX_LinksCanciones_CancionId",
                table: "LinksCanciones");

            migrationBuilder.DropIndex(
                name: "IX_Generos_CancionId",
                table: "Generos");

            migrationBuilder.DropIndex(
                name: "IX_Artistas_CancionId",
                table: "Artistas");

            migrationBuilder.DropColumn(
                name: "CancionId",
                table: "LinksCanciones");

            migrationBuilder.DropColumn(
                name: "CancionId",
                table: "Generos");

            migrationBuilder.DropColumn(
                name: "CancionId",
                table: "Artistas");

            migrationBuilder.CreateTable(
                name: "CancionArtista",
                columns: table => new
                {
                    ArtistasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancionArtista", x => new { x.ArtistasId, x.CancionId });
                    table.ForeignKey(
                        name: "FK_CancionArtista_Artistas_ArtistasId",
                        column: x => x.ArtistasId,
                        principalTable: "Artistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancionArtista_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancionGenero",
                columns: table => new
                {
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenerosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancionGenero", x => new { x.CancionId, x.GenerosId });
                    table.ForeignKey(
                        name: "FK_CancionGenero_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancionGenero_Generos_GenerosId",
                        column: x => x.GenerosId,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancionLinkCancion",
                columns: table => new
                {
                    CancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinksCancionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancionLinkCancion", x => new { x.CancionId, x.LinksCancionId });
                    table.ForeignKey(
                        name: "FK_CancionLinkCancion_Canciones_CancionId",
                        column: x => x.CancionId,
                        principalTable: "Canciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancionLinkCancion_LinksCanciones_LinksCancionId",
                        column: x => x.LinksCancionId,
                        principalTable: "LinksCanciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CancionArtista_CancionId",
                table: "CancionArtista",
                column: "CancionId");

            migrationBuilder.CreateIndex(
                name: "IX_CancionGenero_GenerosId",
                table: "CancionGenero",
                column: "GenerosId");

            migrationBuilder.CreateIndex(
                name: "IX_CancionLinkCancion_LinksCancionId",
                table: "CancionLinkCancion",
                column: "LinksCancionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CancionArtista");

            migrationBuilder.DropTable(
                name: "CancionGenero");

            migrationBuilder.DropTable(
                name: "CancionLinkCancion");

            migrationBuilder.AddColumn<Guid>(
                name: "CancionId",
                table: "LinksCanciones",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CancionId",
                table: "Generos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CancionId",
                table: "Artistas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinksCanciones_CancionId",
                table: "LinksCanciones",
                column: "CancionId");

            migrationBuilder.CreateIndex(
                name: "IX_Generos_CancionId",
                table: "Generos",
                column: "CancionId");

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_CancionId",
                table: "Artistas",
                column: "CancionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artistas_Canciones_CancionId",
                table: "Artistas",
                column: "CancionId",
                principalTable: "Canciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Generos_Canciones_CancionId",
                table: "Generos",
                column: "CancionId",
                principalTable: "Canciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LinksCanciones_Canciones_CancionId",
                table: "LinksCanciones",
                column: "CancionId",
                principalTable: "Canciones",
                principalColumn: "Id");
        }
    }
}
