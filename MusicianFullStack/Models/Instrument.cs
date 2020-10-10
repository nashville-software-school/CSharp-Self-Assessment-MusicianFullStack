using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MusicianFullStack.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DisplayName("Difficulty Level")]
        public int DifficultyId { get; set;  }

        public Difficulty Difficulty { get; set;  }

        [DisplayName("Played by")]
        public List<Musician> Musicians { get; set; }
    }
}
