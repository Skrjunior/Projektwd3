using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWD3.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddHryAndAnimeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime_Filmy_a_Seriály",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokVydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zaner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odkaz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Typ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObrazokCesta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime_Filmy_a_Seriály", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RokVydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Odkaz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zaner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Platforma = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObrazokCesta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hry", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anime_Filmy_a_Seriály");

            migrationBuilder.DropTable(
                name: "Hry");
        }
    }
}
