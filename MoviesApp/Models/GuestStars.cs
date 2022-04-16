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
        public string profile_path { get; set; }
        [ForeignKey("episode_number")]
        public int episode_number { get; set; }
        public Episodes episode { get; set; }

    }
}
