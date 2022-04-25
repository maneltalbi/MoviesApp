using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Crew
    {
        [Key]
        public int idCrew { get; set; }
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string departement { get; set; }
        public string job { get; set; }
        public string profile_path { get; set; }
        [ForeignKey("episodec")]
        public int idEpisode { get; set; }
        public Episodes episodec { get; set; }
    }
}
