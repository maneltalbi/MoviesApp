using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class RootObject1
    {
        public int page { get; set; }
         public List<Series> results { get; set; }

        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
