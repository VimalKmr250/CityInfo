﻿using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class PointOfInterestCreationDto
    {
        [Required]
        [MaxLength(10)]
        public String Name { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(200)]
        public String? Description { get; set; }
    }
}
