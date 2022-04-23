using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Productioncountries
    {
        [Key]
        public int idProdCountry { get; set; }
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
        



    }
}
