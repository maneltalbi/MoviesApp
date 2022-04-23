﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.Data;

namespace MoviesApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesApp.Models.Createurs", b =>
                {
                    b.Property<int>("idCreateur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("credit_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profile_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idCreateur");

                    b.HasIndex("Seriesid");

                    b.ToTable("Createurs");
                });

            modelBuilder.Entity("MoviesApp.Models.Crew", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("credit_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("departement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("episodeidEpisode")
                        .HasColumnType("int");

                    b.Property<int>("idCrew")
                        .HasColumnType("int");

                    b.Property<int>("idEpisode")
                        .HasColumnType("int");

                    b.Property<string>("job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profile_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("episodeidEpisode");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("MoviesApp.Models.EpisodeStar", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idEpisode")
                        .HasColumnType("int");

                    b.Property<int>("idStar")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("EpisodeStar");
                });

            modelBuilder.Entity("MoviesApp.Models.Episodes", b =>
                {
                    b.Property<int>("idEpisode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("episode_number")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("idSeason")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("production_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("season_number")
                        .HasColumnType("int");

                    b.Property<string>("still_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("idEpisode");

                    b.HasIndex("idSeason");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("MoviesApp.Models.EpisodesImages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEpisode")
                        .HasColumnType("int");

                    b.Property<int>("IdImg")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("EpisodesImages");
                });

            modelBuilder.Entity("MoviesApp.Models.EpisodesVideos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idEp")
                        .HasColumnType("int");

                    b.Property<string>("idVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("EpisodesVideos");
                });

            modelBuilder.Entity("MoviesApp.Models.Genres", b =>
                {
                    b.Property<int>("idgenre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idgenre");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesApp.Models.GenresMovies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idGenre")
                        .HasColumnType("int");

                    b.Property<int>("idMovie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("GenresMovies");
                });

            modelBuilder.Entity("MoviesApp.Models.GenresSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idGenre")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("GenresSeries");
                });

            modelBuilder.Entity("MoviesApp.Models.GuestStars", b =>
                {
                    b.Property<int>("idGuest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("adult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("character")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("credit_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gender")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("known_for_department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("order")
                        .HasColumnType("int");

                    b.Property<string>("original_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("popularity")
                        .HasColumnType("float");

                    b.Property<string>("profile_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idGuest");

                    b.ToTable("GuestStars");
                });

            modelBuilder.Entity("MoviesApp.Models.Images", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("aspect_ratio")
                        .HasColumnType("float");

                    b.Property<string>("file_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("height")
                        .HasColumnType("int");

                    b.Property<int>("idImage")
                        .HasColumnType("int");

                    b.Property<string>("iso_639_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.Property<int>("width")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MoviesApp.Models.LastEpisodeToAir", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("episode_number")
                        .HasColumnType("int");

                    b.Property<int>("idLastEpisode")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("production_code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("still_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idSerie");

                    b.ToTable("LastEpisodeToAir");
                });

            modelBuilder.Entity("MoviesApp.Models.Movies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Released")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("adult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("backdrop_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idMovie")
                        .HasColumnType("int");

                    b.Property<int>("imdbRating")
                        .HasColumnType("int");

                    b.Property<double>("imdbVotes")
                        .HasColumnType("float");

                    b.Property<string>("original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("popularity")
                        .HasColumnType("float");

                    b.Property<string>("videos")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesApp.Models.MoviesImages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdImg")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("MoviesImages");
                });

            modelBuilder.Entity("MoviesApp.Models.Networks", b =>
                {
                    b.Property<int>("idNet")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.Property<string>("logo_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idNet");

                    b.HasIndex("idSerie");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("MoviesApp.Models.ProCompMovies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdCompanie")
                        .HasColumnType("int");

                    b.Property<int>("idMovie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProCompMovies");
                });

            modelBuilder.Entity("MoviesApp.Models.ProCompSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdCompanie")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProCompSeries");
                });

            modelBuilder.Entity("MoviesApp.Models.ProdCountrieMovies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdCountrie")
                        .HasColumnType("int");

                    b.Property<int>("idMovie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProdCountrieMovies");
                });

            modelBuilder.Entity("MoviesApp.Models.ProdCountrieSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdCountrie")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ProdCountrieSeries");
                });

            modelBuilder.Entity("MoviesApp.Models.ProductionCompanies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idProdCompany")
                        .HasColumnType("int");

                    b.Property<string>("logo_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductionCompanies");
                });

            modelBuilder.Entity("MoviesApp.Models.Productioncountries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("iso_3166_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Productioncountries");
                });

            modelBuilder.Entity("MoviesApp.Models.Seasons", b =>
                {
                    b.Property<int>("idSeason")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("season_number")
                        .HasColumnType("int");

                    b.HasKey("idSeason");

                    b.HasIndex("idSerie");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MoviesApp.Models.SeasonsImages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdImag")
                        .HasColumnType("int");

                    b.Property<int>("IdSeason")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SeasonsImages");
                });

            modelBuilder.Entity("MoviesApp.Models.Series", b =>
                {
                    b.Property<int>("idSerie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("backdrop_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homepage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("in_production")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("languages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number_of_episodes")
                        .HasColumnType("int");

                    b.Property<int>("number_of_seasons")
                        .HasColumnType("int");

                    b.Property<string>("origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("popularity")
                        .HasColumnType("float");

                    b.Property<string>("poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("tagline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("idSerie");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MoviesApp.Models.SeriesImages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdImg")
                        .HasColumnType("int");

                    b.Property<int>("IdSerie")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SeriesImages");
                });

            modelBuilder.Entity("MoviesApp.Models.SpokenLanguages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("english_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iso_639_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("SpokenLanguages");
                });

            modelBuilder.Entity("MoviesApp.Models.SpokenLggMovies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idMovie")
                        .HasColumnType("int");

                    b.Property<int>("idSpokenlgg")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SpokenLggMovies");
                });

            modelBuilder.Entity("MoviesApp.Models.SpokenLggSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.Property<int>("idSpokenlgg")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SpokenLggSeries");
                });

            modelBuilder.Entity("MoviesApp.Models.VideosSeasons", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idSeason")
                        .HasColumnType("int");

                    b.Property<string>("idVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VideosSeasons");
                });

            modelBuilder.Entity("MoviesApp.Models.VideosSeries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idSerie")
                        .HasColumnType("int");

                    b.Property<string>("idVideo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("VideosSeries");
                });

            modelBuilder.Entity("MoviesApp.Models.videos", b =>
                {
                    b.Property<int>("idVideo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("published_at")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("site")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("size")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idVideo");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("MoviesApp.Models.Createurs", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", "serie")
                        .WithMany("Created_by")
                        .HasForeignKey("Seriesid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("serie");
                });

            modelBuilder.Entity("MoviesApp.Models.Crew", b =>
                {
                    b.HasOne("MoviesApp.Models.Episodes", "episode")
                        .WithMany()
                        .HasForeignKey("episodeidEpisode");

                    b.Navigation("episode");
                });

            modelBuilder.Entity("MoviesApp.Models.Episodes", b =>
                {
                    b.HasOne("MoviesApp.Models.Seasons", "season")
                        .WithMany("episodes")
                        .HasForeignKey("idSeason")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("season");
                });

            modelBuilder.Entity("MoviesApp.Models.LastEpisodeToAir", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", "serie")
                        .WithMany()
                        .HasForeignKey("idSerie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("serie");
                });

            modelBuilder.Entity("MoviesApp.Models.Networks", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", "serie")
                        .WithMany("Networks")
                        .HasForeignKey("idSerie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("serie");
                });

            modelBuilder.Entity("MoviesApp.Models.Seasons", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", "serie")
                        .WithMany("Seasons")
                        .HasForeignKey("idSerie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("serie");
                });

            modelBuilder.Entity("MoviesApp.Models.Seasons", b =>
                {
                    b.Navigation("episodes");
                });

            modelBuilder.Entity("MoviesApp.Models.Series", b =>
                {
                    b.Navigation("Created_by");

                    b.Navigation("Networks");

                    b.Navigation("Seasons");
                });
#pragma warning restore 612, 618
        }
    }
}
