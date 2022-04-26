using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class parts
    {
        [Key]
        public int idPart { get; set; }
        public  string adult { get; set; }
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public double popularity { get; set; }
        public string title { get; set; }
        public string video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        [ForeignKey("collection")]
        public int idCol { get; set; }
        public Collections collection { get; set; }
    }
}
