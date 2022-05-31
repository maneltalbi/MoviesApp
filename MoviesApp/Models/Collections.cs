using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Collections
    {
        [Key]
        public int idCol { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public string backdrop_path { get; set; }
        public List<parts> parts { get; set; }
        [ForeignKey("movie")]
        public int idMovie { get; set; }
        public MyMovie movie { get; set; }

    }
}
