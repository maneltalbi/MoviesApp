using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class SeriesImages
    {
        [Key]
        public int id { get; set; }
        public int IdSerie { get; set; }
        public int IdImg { get; set; }
    }
}
