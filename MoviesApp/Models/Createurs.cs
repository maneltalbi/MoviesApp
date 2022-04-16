using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Createurs
    {
        public int id { get; set; }
        public int credit_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string profile_path { get; set; }
        
    }
}
