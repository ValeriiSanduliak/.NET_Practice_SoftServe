﻿using System.ComponentModel.DataAnnotations;

namespace CinemaAPI.DTOs
{
    public class MovieSessionDTO
    {
        public int MovieSessionId { get; set; }
        public string MovieTitle { get; set; } = null!;
        public TimeOnly StartTime { get; set; }
    }

    public class MovieSessionPostDTO
    {
        [Required(ErrorMessage = "MovieId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "MovieId must be a positive number")]
        public int MovieId { get; set; }

        public TimeOnly? StartTime { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheLowestPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? MiddlePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int? TheHighestPrice { get; set; }

        [Required(ErrorMessage = "HallId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "HallId must be a positive number")]
        public int HallId { get; set; }
    }
}
