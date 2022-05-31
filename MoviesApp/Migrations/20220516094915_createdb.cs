using Microsoft.EntityFrameworkCore.Migrations;

namespace MoviesApp.Migrations
{
    public partial class createdb : Migration
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
                name: "EpisodeStar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEpisode = table.Column<int>(type: "int", nullable: false),
                    idStar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeStar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EpisodesVideos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEp = table.Column<int>(type: "int", nullable: false),
                    idVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodesVideos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    idgenre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.idgenre);
                });

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

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idImage = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Images", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    idMovie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    budget = table.Column<int>(type: "int", nullable: false),
                    homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    imdb_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularty = table.Column<double>(type: "float", nullable: false),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    revenue = table.Column<int>(type: "int", nullable: false),
                    runtime = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.idMovie);
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
                name: "ProCompMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    ProdCompanie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProCompMovies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProCompSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    ProdCompanie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProCompSeries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProdCountrieMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    ProdCountrie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCountrieMovies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProdCountrieSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    ProdCountrie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdCountrieSeries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                columns: table => new
                {
                    idProdCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    logo_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => x.idProdCompany);
                });

            migrationBuilder.CreateTable(
                name: "Productioncountries",
                columns: table => new
                {
                    idProdCountry = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iso_3166_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productioncountries", x => x.idProdCountry);
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
                name: "SeasonsStar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSeason = table.Column<int>(type: "int", nullable: false),
                    idStar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonsStar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    idSerie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Series", x => x.idSerie);
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
                name: "SpokenLanguages",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    english_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    iso_639_1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLggMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    Spokenlgg = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Spokenlgg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLggSeries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    idVideo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<int>(type: "int", nullable: false),
                    published_at = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.idVideo);
                });

            migrationBuilder.CreateTable(
                name: "VideosMovies",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idMovie = table.Column<int>(type: "int", nullable: false),
                    idVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideosMovies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VideosSeasons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSeason = table.Column<int>(type: "int", nullable: false),
                    idVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideosSeasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VideosSeries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idSerie = table.Column<int>(type: "int", nullable: false),
                    idVideo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideosSeries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    idCol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idMovie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.idCol);
                    table.ForeignKey(
                        name: "FK_Collections_Movies_idMovie",
                        column: x => x.idMovie,
                        principalTable: "Movies",
                        principalColumn: "idMovie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Createurs",
                columns: table => new
                {
                    idCreateur = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seriesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Createurs", x => x.idCreateur);
                    table.ForeignKey(
                        name: "FK_Createurs_Series_Seriesid",
                        column: x => x.Seriesid,
                        principalTable: "Series",
                        principalColumn: "idSerie",
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
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    production_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    still_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    episode_number = table.Column<int>(type: "int", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    idSerie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastEpisodeToAir", x => x.id);
                    table.ForeignKey(
                        name: "FK_LastEpisodeToAir_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "idSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                columns: table => new
                {
                    idNet = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    logo_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    origin_country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idSerie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => x.idNet);
                    table.ForeignKey(
                        name: "FK_Networks_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "idSerie",
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
                    idSerie = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.idSeason);
                    table.ForeignKey(
                        name: "FK_Seasons_Series_idSerie",
                        column: x => x.idSerie,
                        principalTable: "Series",
                        principalColumn: "idSerie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parts",
                columns: table => new
                {
                    idPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    backdrop_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id = table.Column<int>(type: "int", nullable: false),
                    original_language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    release_date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    poster_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<double>(type: "float", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vote_average = table.Column<double>(type: "float", nullable: false),
                    vote_count = table.Column<int>(type: "int", nullable: false),
                    idCol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parts", x => x.idPart);
                    table.ForeignKey(
                        name: "FK_parts_Collections_idCol",
                        column: x => x.idCol,
                        principalTable: "Collections",
                        principalColumn: "idCol",
                        onDelete: ReferentialAction.Cascade);
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
                    idCrew = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.idCrew);
                    table.ForeignKey(
                        name: "FK_Crew_Episodes_idEp",
                        column: x => x.idEp,
                        principalTable: "Episodes",
                        principalColumn: "idEpisode",
                        onDelete: ReferentialAction.Cascade);
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
                    gender = table.Column<int>(type: "int", nullable: false),
                    adult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    known_for_department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    original_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    popularity = table.Column<double>(type: "float", nullable: false),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idEpisode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestStars", x => x.idGuest);
                    table.ForeignKey(
                        name: "FK_GuestStars_Episodes_idEpisode",
                        column: x => x.idEpisode,
                        principalTable: "Episodes",
                        principalColumn: "idEpisode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_idMovie",
                table: "Collections",
                column: "idMovie");

            migrationBuilder.CreateIndex(
                name: "IX_Createurs_Seriesid",
                table: "Createurs",
                column: "Seriesid");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_idEp",
                table: "Crew",
                column: "idEp");

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_idSeason",
                table: "Episodes",
                column: "idSeason");

            migrationBuilder.CreateIndex(
                name: "IX_GuestStars_idEpisode",
                table: "GuestStars",
                column: "idEpisode");

            migrationBuilder.CreateIndex(
                name: "IX_LastEpisodeToAir_idSerie",
                table: "LastEpisodeToAir",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_idSerie",
                table: "Networks",
                column: "idSerie");

            migrationBuilder.CreateIndex(
                name: "IX_parts_idCol",
                table: "parts",
                column: "idCol");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_idSerie",
                table: "Seasons",
                column: "idSerie");
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
                name: "EpisodeStar");

            migrationBuilder.DropTable(
                name: "EpisodesVideos");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "GenresMovies");

            migrationBuilder.DropTable(
                name: "GenresSeries");

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
                name: "parts");

            migrationBuilder.DropTable(
                name: "ProCompMovies");

            migrationBuilder.DropTable(
                name: "ProCompSeries");

            migrationBuilder.DropTable(
                name: "ProdCountrieMovies");

            migrationBuilder.DropTable(
                name: "ProdCountrieSeries");

            migrationBuilder.DropTable(
                name: "ProductionCompanies");

            migrationBuilder.DropTable(
                name: "Productioncountries");

            migrationBuilder.DropTable(
                name: "SeasonsImages");

            migrationBuilder.DropTable(
                name: "SeasonsStar");

            migrationBuilder.DropTable(
                name: "SeriesImages");

            migrationBuilder.DropTable(
                name: "SpokenLanguages");

            migrationBuilder.DropTable(
                name: "SpokenLggMovies");

            migrationBuilder.DropTable(
                name: "SpokenLggSeries");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "VideosMovies");

            migrationBuilder.DropTable(
                name: "VideosSeasons");

            migrationBuilder.DropTable(
                name: "VideosSeries");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
