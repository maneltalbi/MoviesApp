using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Createurs> Createurs { get; set; }
        public DbSet<LastEpisodeToAir> LastEpisodeToAir { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Networks> Networks { get; set; }
        public DbSet<ProductionCompanies> ProductionCompanies { get; set; }
        public DbSet<Productioncountries> Productioncountries { get; set; }
        public DbSet<Seasons> Seasons { get; set; }
        public DbSet<SpokenLanguages> SpokenLanguages { get; set; }



    }
}
