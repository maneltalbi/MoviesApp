using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class LastEpisodeToAir
    {
        [Key]
        public int id { get; set; }
        public int idLastEpisode { get; set; }
        public string air_date { get; set; }
        public int episode_number { get; set; }

    }
}
