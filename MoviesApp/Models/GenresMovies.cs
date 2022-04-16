using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class GenresMovies
    {
        [Key]
        public int id { get; set; }
        public int idMovie { get; set; }
        public int idGenre { get; set; }
    }
}
