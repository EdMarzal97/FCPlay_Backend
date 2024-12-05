using System;
using System.ComponentModel.DataAnnotations;

namespace FCPlay.Models {
    public class Match {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? TeamLocal {get; set;}
        [Required]
        public string? TeamAway  {get; set;}
        [Required]
        public DateTime MatchDate{ get; set; }

        public int ScoreLocal{ get; set; }
        public int ScoreAway{ get; set; }
    }
}