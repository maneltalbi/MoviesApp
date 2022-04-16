using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class SeasonsImages
    {
        [Key]
        public int id { get; set; }
        public int IdSeason { get; set; }
        public int IdImag { get; set; }
    }
}
