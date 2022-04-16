using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class modifyCountrieandcompanie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_Series_idSerie",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanies_Movies_idMovie",
                table: "ProductionCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanies_Series_idSerie",
                table: "ProductionCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Productioncountries_Movies_idMovie",
                table: "Productioncountries");

            migrationBuilder.DropForeignKey(
                name: "FK_Productioncountries_Series_idSerie",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_Productioncountries_idMovie",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_Productioncountries_idSerie",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_ProductionCompanies_idMovie",
                table: "ProductionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ProductionCompanies_idSerie",
                table: "ProductionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Genres_idSerie",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "idMovie",
                table: "Productioncountries");

            migrationBuilder.DropColumn(
                name: "idSerie",
                table: "Productioncountries");

            migrationBuilder.DropColumn(
                name: "idMovie",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "idSerie",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "idSerie",
                table: "Genres");

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

            migrationBuilder.CreateTable(
                name: "GenresMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    idGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresMovies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GenresSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idGenre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresSeries", x => x.id);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "GenresSeries");

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

            migrationBuilder.AddColumn<int>(
                name: "idMovie",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSerie",
                table: "Productioncountries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idMovie",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSerie",
                table: "ProductionCompanies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idSerie",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_idMovie",
                table: "Productioncountries",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_idSerie",
                table: "Productioncountries",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_idMovie",
                table: "ProductionCompanies",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_idSerie",
                table: "ProductionCompanies",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_idSerie",
                table: "Genres",
                column: "idSerie");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_Series_idSerie",
                table: "Genres",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanies_Movies_idMovie",
                table: "ProductionCompanies",
                column: "idMovie",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanies_Series_idSerie",
                table: "ProductionCompanies",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productioncountries_Movies_idMovie",
                table: "Productioncountries",
                column: "idMovie",
                principalTable: "Movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productioncountries_Series_idSerie",
                table: "Productioncountries",
                column: "idSerie",
                principalTable: "Series",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
