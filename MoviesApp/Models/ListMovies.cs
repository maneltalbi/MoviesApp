using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ListMovies
    {
        public Collections belongs_to_collection { get; set; }
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public int budget { get; set; }
        public List<Genres> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularty { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompanies> production_companies { get; set; }
        public List<Productioncountries> production_countries { get; set; }
        public string release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public List<SpokenLanguages> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }





    }
}
