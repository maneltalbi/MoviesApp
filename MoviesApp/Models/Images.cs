using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Images
    {
        [Key]
        public int id { get; set; }
        public int idImage { get; set; }
        public double aspect_ratio { get; set; }
        public string file_path { get; set; }
        public int height { get; set; }
        public string iso_639_1 { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public int width { get; set; }

    }
}
