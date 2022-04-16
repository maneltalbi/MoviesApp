using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class deleteResultSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Createurs_ResultSeries_ResultSeriesid",
                table: "Createurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Genres_ResultSeries_ResultSeriesid",
                table: "Genres");

            migrationBuilder.DropForeignKey(
                name: "FK_LastEpisodeToAir_ResultSeries_ResultSeriesid",
                table: "LastEpisodeToAir");

            migrationBuilder.DropForeignKey(
                name: "FK_Networks_ResultSeries_ResultSeriesid",
                table: "Networks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductionCompanies_ResultSeries_ResultSeriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropForeignKey(
                name: "FK_Productioncountries_ResultSeries_ResultSeriesid",
                table: "Productioncountries");

            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_ResultSeries_ResultSeriesid",
                table: "Seasons");

            migrationBuilder.DropForeignKey(
                name: "FK_SpokenLanguages_ResultSeries_ResultSeriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "ResultSeries");

            migrationBuilder.DropIndex(
                name: "IX_SpokenLanguages_ResultSeriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_ResultSeriesid",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Productioncountries_ResultSeriesid",
                table: "Productioncountries");

            migrationBuilder.DropIndex(
                name: "IX_ProductionCompanies_ResultSeriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropIndex(
                name: "IX_Networks_ResultSeriesid",
                table: "Networks");

            migrationBuilder.DropIndex(
                name: "IX_LastEpisodeToAir_ResultSeriesid",
                table: "LastEpisodeToAir");

            migrationBuilder.DropIndex(
                name: "IX_Genres_ResultSeriesid",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Createurs_ResultSeriesid",
                table: "Createurs");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "Productioncountries");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "ProductionCompanies");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "Networks");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "LastEpisodeToAir");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "ResultSeriesid",
                table: "Createurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "SpokenLanguages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "Seasons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "Productioncountries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "ProductionCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "Networks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "LastEpisodeToAir",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "Genres",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResultSeriesid",
                table: "Createurs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResultSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    in_production = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    number_of_episodes = table.Column<int>(type: "int", nullable: false),
                    number_of_seasons = table.Column<int>(type: "int", nullable: false),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<double>(type: "float", nullable: false),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultSeries", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ResultSeriesid",
                table: "SpokenLanguages",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ResultSeriesid",
                table: "Seasons",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_ResultSeriesid",
                table: "Productioncountries",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_ResultSeriesid",
                table: "ProductionCompanies",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_ResultSeriesid",
                table: "Networks",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_LastEpisodeToAir_ResultSeriesid",
                table: "LastEpisodeToAir",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ResultSeriesid",
                table: "Genres",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Createurs_ResultSeriesid",
                table: "Createurs",
                column: "ResultSeriesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Createurs_ResultSeries_ResultSeriesid",
                table: "Createurs",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_ResultSeries_ResultSeriesid",
                table: "Genres",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LastEpisodeToAir_ResultSeries_ResultSeriesid",
                table: "LastEpisodeToAir",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Networks_ResultSeries_ResultSeriesid",
                table: "Networks",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductionCompanies_ResultSeries_ResultSeriesid",
                table: "ProductionCompanies",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productioncountries_ResultSeries_ResultSeriesid",
                table: "Productioncountries",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_ResultSeries_ResultSeriesid",
                table: "Seasons",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpokenLanguages_ResultSeries_ResultSeriesid",
                table: "SpokenLanguages",
                column: "ResultSeriesid",
                principalTable: "ResultSeries",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
