using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class modification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Movies_Moviesid",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanies_Movies_Moviesid",
                table: "ProductionCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanies_Series_Seriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Productioncountries_Movies_Moviesid",
                table: "Productioncountries");

            migrationBuilder.DropForeignKey(
                name: "FK_Productioncountries_Series_Seriesid",
                table: "Productioncountries");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Movies_idMovie",
                table: "SpokenLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Series_idSerie",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_SpokenLanguages_idMovie",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_SpokenLanguages_idSerie",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Productioncountries_Moviesid",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_Productioncountries_Seriesid",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_ProductionCompanies_Moviesid",
                table: "ProductionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ProductionCompanies_Seriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_Moviesid",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "idMovie",
                table: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "idSerie",
                table: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "Moviesid",
                table: "Productioncountries");

            migrationBuilder.DropColumn(
                name: "Seriesid",
                table: "Productioncountries");

            migrationBuilder.DropColumn(
                name: "Moviesid",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "Seriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "Moviesid",
                table: "Genres");

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

            migrationBuilder.CreateTable(
                name: "SpokenLggMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    idSpokenlgg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLggMovies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLggSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idSpokenlgg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLggSeries", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Movies_Moviesid",
                table: "SpokenLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_Series_Seriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "SpokenLggMovies");

            migrationBuilder.DropTable(
                name: "SpokenLggSeries");

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

            migrationBuilder.AddColumn<int>(
                name: "idMovie",
                table: "SpokenLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSerie",
                table: "SpokenLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Moviesid",
                table: "Productioncountries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seriesid",
                table: "Productioncountries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moviesid",
                table: "ProductionCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Seriesid",
                table: "ProductionCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Moviesid",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_idMovie",
                table: "SpokenLanguages",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_idSerie",
                table: "SpokenLanguages",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_Moviesid",
                table: "Productioncountries",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_Seriesid",
                table: "Productioncountries",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_Moviesid",
                table: "ProductionCompanies",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_Seriesid",
                table: "ProductionCompanies",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Moviesid",
                table: "Genres",
                column: "Moviesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Movies_Moviesid",
                table: "Genres",
                column: "Moviesid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanies_Movies_Moviesid",
                table: "ProductionCompanies",
                column: "Moviesid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanies_Series_Seriesid",
                table: "ProductionCompanies",
                column: "Seriesid",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productioncountries_Movies_Moviesid",
                table: "Productioncountries",
                column: "Moviesid",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productioncountries_Series_Seriesid",
                table: "Productioncountries",
                column: "Seriesid",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_Movies_idMovie",
                table: "SpokenLanguages",
                column: "idMovie",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_Series_idSerie",
                table: "SpokenLanguages",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
