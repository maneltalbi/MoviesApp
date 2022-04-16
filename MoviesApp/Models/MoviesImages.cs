using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{

    public class MoviesImages
    {
        [Key]
        public int id { get; set; }
        public int IdMovie { get; set; }
        public int IdImg { get; set; }
    }
}
