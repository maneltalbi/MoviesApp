using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class seriestab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "backdrop_path",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "homepage",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idSerie",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "in_production",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "languages",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "last_air_date",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "number_of_episodes",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "number_of_seasons",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "origin_country",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "origin_language",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "origin_name",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "popularity",
                table: "Series",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tagline",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "Series",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Createurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCreateur = table.Column<int>(type: "int", nullable: false),
                    credit_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Createurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Createurs_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                    table.ForeignKey(
                        name: "FK_Genres_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LastEpisodeToAir",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLastEpisode = table.Column<int>(type: "int", nullable: false),
                    air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_number = table.Column<int>(type: "int", nullable: false),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastEpisodeToAir", x => x.id);
                    table.ForeignKey(
                        name: "FK_LastEpisodeToAir_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idNetwork = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Networks_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProdCompany = table.Column<int>(type: "int", nullable: false),
                    logo_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productioncountries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso_3166_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productioncountries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productioncountries_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSeason = table.Column<int>(type: "int", nullable: false),
                    air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    season_number = table.Column<int>(type: "int", nullable: false),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.id);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    english_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iso_639_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Createurs_Seriesid",
                table: "Createurs",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Seriesid",
                table: "Genres",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_LastEpisodeToAir_Seriesid",
                table: "LastEpisodeToAir",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_Seriesid",
                table: "Networks",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_Seriesid",
                table: "ProductionCompanies",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_Seriesid",
                table: "Productioncountries",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_Seriesid",
                table: "Seasons",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_Seriesid",
                table: "SpokenLanguages",
                column: "Seriesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Createurs");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "LastEpisodeToAir");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "ProductionCompanies");

            migrationBuilder.DropTable(
                name: "Productioncountries");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "SpokenLanguages");

            migrationBuilder.DropColumn(
                name: "backdrop_path",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "homepage",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "idSerie",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "in_production",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "languages",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "last_air_date",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "number_of_episodes",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "number_of_seasons",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "origin_country",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "origin_language",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "origin_name",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "popularity",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "status",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "tagline",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Series");
        }
    }
}
