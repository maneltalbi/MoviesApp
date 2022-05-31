using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Videos
    {
     
        public int idMovie { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string site { get; set; }
        public string key { get; set; }
        public string type { get; set; }
        public int size { get; set; }
        public string published_at { get; set; }
        


    }
}
