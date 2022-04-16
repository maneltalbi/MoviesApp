using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class listVideos
    {
     
        public int id { get; set; }
        public List<Videos> results { get; set; }
        [ForeignKey("serie")]
        public int idSerie { get; set; }
        public Series serie { get; set; }





    }
}
