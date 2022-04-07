using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class addrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "adult",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "backdrop_path",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genres",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idMovie",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "original_language",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "original_title",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "popularity",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "video",
                table: "Movies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adult",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "backdrop_path",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "genres",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "idMovie",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_language",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "original_title",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "popularity",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "video",
                table: "Movies");
        }
    }
}
