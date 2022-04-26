using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ResultImg
    {
        public int id { get; set; }
        public List<Posters> posters { get; set; }

        public List<backdrops> backdrops { get; set; }
        public List<stills> stills { get; set; }
        public List<backdrops> logos { get; set; }


    }
}
