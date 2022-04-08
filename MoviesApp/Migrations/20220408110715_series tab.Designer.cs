﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.Data;

namespace MoviesApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220408110715_series tab")]
    partial class seriestab
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesApp.Models.Createurs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<int>("credit_id")
                        .HasColumnType("int");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idCreateur")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profile_path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("Createurs");
                });

            modelBuilder.Entity("MoviesApp.Models.Genres", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MoviesApp.Models.LastEpisodeToAir", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("episode_number")
                        .HasColumnType("int");

                    b.Property<int>("idLastEpisode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

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

                    b.Property<string>("genres")
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

            modelBuilder.Entity("MoviesApp.Models.Networks", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<int>("idNetwork")
                        .HasColumnType("int");

                    b.Property<string>("logo_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("Networks");
                });

            modelBuilder.Entity("MoviesApp.Models.ProductionCompanies", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<int>("idProdCompany")
                        .HasColumnType("int");

                    b.Property<string>("logo_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_country")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("ProductionCompanies");
                });

            modelBuilder.Entity("MoviesApp.Models.Productioncountries", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("iso_3166_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("Productioncountries");
                });

            modelBuilder.Entity("MoviesApp.Models.Seasons", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("episode_count")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSeason")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("season_number")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MoviesApp.Models.Series", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("backdrop_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homepage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSerie")
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

                    b.Property<string>("origin_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("origin_name")
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

                    b.HasKey("id");

                    b.ToTable("Series");
                });

            modelBuilder.Entity("MoviesApp.Models.SpokenLanguages", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Seriesid")
                        .HasColumnType("int");

                    b.Property<string>("english_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iso_639_1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Seriesid");

                    b.ToTable("SpokenLanguages");
                });

            modelBuilder.Entity("MoviesApp.Models.Createurs", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("Created_by")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.Genres", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("genres")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.LastEpisodeToAir", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("last_episode_to_air")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.Networks", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("Networks")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.ProductionCompanies", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("ProductionCompanies")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.Productioncountries", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("Productioncountries")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.Seasons", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("Seasons")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.SpokenLanguages", b =>
                {
                    b.HasOne("MoviesApp.Models.Series", null)
                        .WithMany("SpokenLanguages")
                        .HasForeignKey("Seriesid");
                });

            modelBuilder.Entity("MoviesApp.Models.Series", b =>
                {
                    b.Navigation("Created_by");

                    b.Navigation("genres");

                    b.Navigation("last_episode_to_air");

                    b.Navigation("Networks");

                    b.Navigation("ProductionCompanies");

                    b.Navigation("Productioncountries");

                    b.Navigation("Seasons");

                    b.Navigation("SpokenLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
