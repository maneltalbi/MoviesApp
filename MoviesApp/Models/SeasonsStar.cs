using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class SeasonsStar
    {
        [Key]
        public int id { get; set; }
        public int idSeason { get; set; }
        public int idStar { get; set; }
    }
}
