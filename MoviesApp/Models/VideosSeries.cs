using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class VideosSeries
    {
        [Key]
        public int id { get; set; }
        public int idSerie { get; set; }
        public string idVideo { get; set; }
    }
}
