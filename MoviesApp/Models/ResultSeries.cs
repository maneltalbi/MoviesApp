﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ResultSeries
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Createurs> Created_by { get; set; }
        public string first_air_date { get; set; }
        public string backdrop_path { get; set; }
        public int[] genre_ids { get; set; }
        public string homepage { get; set; }
        public string in_production { get; set; }
        public string languages { get; set; }
        public string last_air_date { get; set; }
        public List<LastEpisodeToAir> last_episode_to_air { get; set; }
        public List<Networks> Networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public string origin_country { get; set; }
        public string origin_language { get; set; }
        public string origin_name { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompanies> ProductionCompanies { get; set; }
        public List<Productioncountries> Productioncountries { get; set; }
        public List<Seasons> Seasons { get; set; }
        public List<SpokenLanguages> SpokenLanguages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string type { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }


    }


}
