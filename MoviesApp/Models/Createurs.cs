using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Createurs
    {
        [Key]
        public int idCreateur { get; set; }
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string profile_path { get; set; }
        [ForeignKey("serie")]
        public int Seriesid { get; set; }
        public Series serie { get; set; }


    }
}
