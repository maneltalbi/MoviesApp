using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class SpokenLanguages
    {
        [Key]
        public int idSpkenLgge { get; set; }
        public string english_name { get; set; }
        public string iso_639_1 { get; set; }
        public string name { get; set; }
        


    }
}