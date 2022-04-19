using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Networks
    {
        [Key]
        public int idNet { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string logo_path { get; set; }
        public string origin_country { get; set; }
        [ForeignKey("serie")]
        public int idSerie { get; set; }
        public Series serie { get; set; }


    }
}
