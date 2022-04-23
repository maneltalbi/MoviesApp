using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class EpisodeStar
    {
        [Key]
        public int id { get; set; }
        public int idEpisode { get; set; }
        public int idStar { get; set; }
    }
}
