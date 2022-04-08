using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Seasons
    {
        [Key]
        public int id { get; set; }
        public int idSeason { get; set; }
        public string  air_date { get; set; }
        public string episode_count { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }




    }
}
