﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoviesApp.Data;

namespace MoviesApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220407115408_stringvideo")]
    partial class stringvideo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MoviesApp.Models.Movie", b =>
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

                    b.Property<double>("imdbRating")
                        .HasColumnType("float");

                    b.Property<double>("imdbVotes")
                        .HasColumnType("float");

                    b.Property<string>("original_language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("original_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("popularity")
                        .HasColumnType("int");

                    b.Property<string>("video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MoviesApp.Models.Series", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("first_air_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("poster_path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("vote_average")
                        .HasColumnType("float");

                    b.Property<int>("vote_count")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Series");
                });
#pragma warning restore 612, 618
        }
    }
}
