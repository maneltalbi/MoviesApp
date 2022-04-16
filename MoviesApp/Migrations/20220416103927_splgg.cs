using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class splgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Movies_Moviesid",
                table: "SpokenLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Series_Seriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_SpokenLanguages_Moviesid",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_SpokenLanguages_Seriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "Moviesid",
                table: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "Seriesid",
                table: "SpokenLanguages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Moviesid",
                table: "SpokenLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seriesid",
                table: "SpokenLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_Moviesid",
                table: "SpokenLanguages",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_Seriesid",
                table: "SpokenLanguages",
                column: "Seriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_Movies_Moviesid",
                table: "SpokenLanguages",
                column: "Moviesid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_Series_Seriesid",
                table: "SpokenLanguages",
                column: "Seriesid",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
