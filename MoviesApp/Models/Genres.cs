using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Genres
    {
        [Key]
        public int idgenre { get; set; }
        public int id { get; set; }
        public string name { get; set; }
       


    }
}
