using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class GuestStars
    {
        [Key]
        public int idGuest { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string credit_id { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public int gender { get; set; }
        public string adult { get; set; }
        public string known_for_department { get; set; }
        public string original_name { get; set; }
        public double popularity { get; set; }
        public string profile_path { get; set; }
        [ForeignKey("episode")]
        public int idEpisode { get; set; }
        public Episodes episode { get; set; }

    }
}
