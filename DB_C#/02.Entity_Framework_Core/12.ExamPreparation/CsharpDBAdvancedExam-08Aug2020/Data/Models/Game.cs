﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VaporStore.Data.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        [ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; } = new HashSet<Purchase>();

        public virtual ICollection<GameTag> GameTags { get; set; } = new HashSet<GameTag>();

    }
}
