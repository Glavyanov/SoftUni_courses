﻿using System.ComponentModel.DataAnnotations;
using Watchlist.Data.Entities;
using static Watchlist.Data.ValidationConstants.MovieConstants;


namespace Watchlist.Models
{
    public class MoviesAddViewModel 
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DirectorMaxLength, MinimumLength = DirectorMinLength,
             ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.00", "10.00", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
    }
}
