using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Createurs> Createurs { get; set; }
        public DbSet<LastEpisodeToAir> LastEpisodeToAir { get; set; }
        public DbSet<Networks> Networks { get; set; }
        public DbSet<ProductionCompanies> ProductionCompanies { get; set; }
        public DbSet<Productioncountries> Productioncountries { get; set; }
        public DbSet<Seasons> Seasons { get; set; }
        public DbSet<SpokenLanguages> SpokenLanguages { get; set; }
        public DbSet<videos> videos { get; set; }
        public DbSet<VideosSeries> VideosSeries { get; set; }

        public DbSet<Genres> Genres { get; set; }
        public DbSet<Episodes> Episodes { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<GuestStars> GuestStars { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<MoviesImages> MoviesImages { get; set; }

        public DbSet<SeriesImages> SeriesImages { get; set; }

        public DbSet<EpisodesImages> EpisodesImages { get; set; }
        public DbSet<SeasonsImages> SeasonsImages { get; set; }
        public DbSet<GenresMovies> GenresMovies { get; set; }

        public DbSet<GenresSeries> GenresSeries { get; set; }
        public DbSet<ProCompMovies> ProCompMovies { get; set; }
        public DbSet<ProdCountrieSeries> ProdCountrieSeries { get; set; }
        public DbSet<ProdCountrieMovies> ProdCountrieMovies { get; set; }
        public DbSet<ProCompSeries> ProCompSeries { get; set; }
        public DbSet<SpokenLggMovies> SpokenLggMovies { get; set; }
        public DbSet<SpokenLggSeries> SpokenLggSeries { get; set; }
        public DbSet<VideosSeasons> VideosSeasons { get; set; }
        public DbSet<EpisodesVideos> EpisodesVideos { get; set; }
        public DbSet<EpisodeStar> EpisodeStar { get; set; }
        public DbSet<SeasonsStar> SeasonsStar { get; set; }
        public DbSet<parts> parts { get; set; }
        public DbSet<Collections> Collections { get; set; }




    }
}
