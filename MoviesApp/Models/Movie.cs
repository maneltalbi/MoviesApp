using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Movie
    {
       [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Type { get; set; }
        public double imdbRating { get; set; }
        public double imdbVotes { get; set; }

    }
}
