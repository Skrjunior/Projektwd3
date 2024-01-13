using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjektWD3.Data.Migrations
{
    /// <inheritdoc />
    public partial class Anime_Filmy_a_Seriály : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ObrazokCesta",
                table: "Anime_Filmy_a_Seriály",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ObrazokCesta",
                table: "Anime_Filmy_a_Seriály",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
