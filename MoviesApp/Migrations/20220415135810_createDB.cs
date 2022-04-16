using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class createDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodesImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdImg = table.Column<int>(type: "int", nullable: false),
                    IdEpisode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodesImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    idImage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aspect_ratio = table.Column<double>(type: "float", nullable: false),
                    file_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    height = table.Column<int>(type: "int", nullable: false),
                    iso_639_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    width = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.idImage);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<double>(type: "float", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Released = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imdbVotes = table.Column<double>(type: "float", nullable: false),
                    imdbRating = table.Column<int>(type: "int", nullable: false),
                    videos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MoviesImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovie = table.Column<int>(type: "int", nullable: false),
                    IdImg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviesImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ResultSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    in_production = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SeasonsImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSeason = table.Column<int>(type: "int", nullable: false),
                    IdImag = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    first_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    genres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    in_production = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    languages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    last_air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Series", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SeriesImages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSerie = table.Column<int>(type: "int", nullable: false),
                    IdImg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesImages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Createurs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    credit_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Createurs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Createurs_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    Moviesid = table.Column<int>(type: "int", nullable: true),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.id);
                    table.ForeignKey(
                        name: "FK_Genres_Movies_Moviesid",
                        column: x => x.Moviesid,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genres_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Genres_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastEpisodeToAir", x => x.id);
                    table.ForeignKey(
                        name: "FK_LastEpisodeToAir_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LastEpisodeToAir_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "listVideos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listVideos", x => x.id);
                    table.ForeignKey(
                        name: "FK_listVideos_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Networks_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Networks_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => x.id);
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_Movies_idMovie",
                        column: x => x.idMovie,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Productioncountries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso_3166_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productioncountries", x => x.id);
                    table.ForeignKey(
                        name: "FK_Productioncountries_Movies_idMovie",
                        column: x => x.idMovie,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productioncountries_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productioncountries_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    idSeason = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    season_number = table.Column<int>(type: "int", nullable: false),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.idSeason);
                    table.ForeignKey(
                        name: "FK_Seasons_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    ResultSeriesid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.id);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_Movies_idMovie",
                        column: x => x.idMovie,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_ResultSeries_ResultSeriesid",
                        column: x => x.ResultSeriesid,
                        principalTable: "ResultSeries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultvideo",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<int>(type: "int", nullable: false),
                    published_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    listVideosid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultvideo", x => x.id);
                    table.ForeignKey(
                        name: "FK_Resultvideo_listVideos_listVideosid",
                        column: x => x.listVideosid,
                        principalTable: "listVideos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    idEpisode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_number = table.Column<int>(type: "int", nullable: false),
                    air_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    production_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    season_number = table.Column<int>(type: "int", nullable: false),
                    still_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    idSeason = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.idEpisode);
                    table.ForeignKey(
                        name: "FK_Episodes_Seasons_idSeason",
                        column: x => x.idSeason,
                        principalTable: "Seasons",
                        principalColumn: "idSeason",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCrew = table.Column<int>(type: "int", nullable: false),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_number = table.Column<int>(type: "int", nullable: false),
                    episodeidEpisode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.id);
                    table.ForeignKey(
                        name: "FK_Crew_Episodes_episodeidEpisode",
                        column: x => x.episodeidEpisode,
                        principalTable: "Episodes",
                        principalColumn: "idEpisode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestStars",
                columns: table => new
                {
                    idGuest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    order = table.Column<int>(type: "int", nullable: false),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_number = table.Column<int>(type: "int", nullable: false),
                    episodeidEpisode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestStars", x => x.idGuest);
                    table.ForeignKey(
                        name: "FK_GuestStars_Episodes_episodeidEpisode",
                        column: x => x.episodeidEpisode,
                        principalTable: "Episodes",
                        principalColumn: "idEpisode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Createurs_ResultSeriesid",
                table: "Createurs",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Createurs_Seriesid",
                table: "Createurs",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_episodeidEpisode",
                table: "Crew",
                column: "episodeidEpisode");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_idSeason",
                table: "Episodes",
                column: "idSeason");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_idSerie",
                table: "Genres",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Moviesid",
                table: "Genres",
                column: "Moviesid");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ResultSeriesid",
                table: "Genres",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_GuestStars_episodeidEpisode",
                table: "GuestStars",
                column: "episodeidEpisode");

            migrationBuilder.CreateIndex(
                name: "IX_LastEpisodeToAir_idSerie",
                table: "LastEpisodeToAir",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_LastEpisodeToAir_ResultSeriesid",
                table: "LastEpisodeToAir",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_listVideos_idSerie",
                table: "listVideos",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_idSerie",
                table: "Networks",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_ResultSeriesid",
                table: "Networks",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_idMovie",
                table: "ProductionCompanies",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_idSerie",
                table: "ProductionCompanies",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_ResultSeriesid",
                table: "ProductionCompanies",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_idMovie",
                table: "Productioncountries",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_idSerie",
                table: "Productioncountries",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Productioncountries_ResultSeriesid",
                table: "Productioncountries",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Resultvideo_listVideosid",
                table: "Resultvideo",
                column: "listVideosid");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_idSerie",
                table: "Seasons",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_ResultSeriesid",
                table: "Seasons",
                column: "ResultSeriesid");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_idMovie",
                table: "SpokenLanguages",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_idSerie",
                table: "SpokenLanguages",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_ResultSeriesid",
                table: "SpokenLanguages",
                column: "ResultSeriesid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Createurs");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "EpisodesImages");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GuestStars");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "LastEpisodeToAir");

            migrationBuilder.DropTable(
                name: "MoviesImages");

            migrationBuilder.DropTable(
                name: "Networks");

            migrationBuilder.DropTable(
                name: "ProductionCompanies");

            migrationBuilder.DropTable(
                name: "Productioncountries");

            migrationBuilder.DropTable(
                name: "Resultvideo");

            migrationBuilder.DropTable(
                name: "SeasonsImages");

            migrationBuilder.DropTable(
                name: "SeriesImages");

            migrationBuilder.DropTable(
                name: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "listVideos");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "ResultSeries");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
