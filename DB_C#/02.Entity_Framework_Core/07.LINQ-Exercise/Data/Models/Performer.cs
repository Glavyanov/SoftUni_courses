﻿using MusicHub.Data.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicHub.Data.Models
{
    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PerformerFirstNamesMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PerformerLastNamesMaxLength)]
        public string LastName { get; set; }

        public int Age { get; set; }    

        public decimal NetWorth { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
