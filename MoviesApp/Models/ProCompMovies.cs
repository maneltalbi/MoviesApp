﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class ProCompMovies
    {
        [Key]
        public int id { get; set; }
        public int idMovie { get; set; }
        public int ProdCompanie { get; set; }
    }
}
