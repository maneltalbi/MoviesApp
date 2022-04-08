using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Movies
    {
        [Key]
        public int id { get; set; }
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public int idMovie { get; set; }
        public string genres { get; set; }
        public string original_title { get; set; }
        public string Poster { get; set; }
        public double popularity { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public double imdbVotes { get; set; }
        public int imdbRating { get; set; }
        public string videos { get; set; }
        public string Overview { get; set; }
        public string original_language { get; set; }


    }
}
