using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Series
    {
       
        public int id { get; set; }
        public string name { get; set; }
        public string poster_path { get; set; }
        public string first_air_date { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }
        public string overview { get; set; }
       
    }


}
