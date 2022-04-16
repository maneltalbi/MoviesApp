using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Crew
    {
        public int idCrew { get; set; }
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string departement { get; set; }
        public string job { get; set; }
        public string profile_path { get; set; }
        [ForeignKey("episode_number")]
        public int episode_number { get; set; }
        public Episodes episode { get; set; }
    }
}
