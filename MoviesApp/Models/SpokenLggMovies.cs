using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class SpokenLggMovies
    {
        [Key]
        public int id { get; set; }
        public int idMovie { get; set; }
        public int idSpokenlgg { get; set; }
    }
}
