﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class HeroisBatalhasIdentidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois");

            migrationBuilder.DropIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois");

            migrationBuilder.DropColumn(
                name: "BatalhaId",
                table: "Herois");

            migrationBuilder.CreateTable(
                name: "heroiBatalhas",
                columns: table => new
                {
                    HeroiId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_heroiBatalhas", x => new { x.BatalhaId, x.HeroiId });
                    table.ForeignKey(
                        name: "FK_heroiBatalhas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_heroiBatalhas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadeSecretas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeReal = table.Column<int>(type: "int", nullable: false),
                    HeroiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadeSecretas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentidadeSecretas_Herois_HeroiId",
                        column: x => x.HeroiId,
                        principalTable: "Herois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_heroiBatalhas_HeroiId",
                table: "heroiBatalhas",
                column: "HeroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadeSecretas_HeroiId",
                table: "IdentidadeSecretas",
                column: "HeroiId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "heroiBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadeSecretas");

            migrationBuilder.AddColumn<int>(
                name: "BatalhaId",
                table: "Herois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Herois_BatalhaId",
                table: "Herois",
                column: "BatalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Herois_Batalhas_BatalhaId",
                table: "Herois",
                column: "BatalhaId",
                principalTable: "Batalhas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
