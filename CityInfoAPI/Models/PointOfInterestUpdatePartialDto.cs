using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models;

public class PointOfInterestUpdatePartialDto
{
    [Required]
    [MaxLength(10)]
    public string Name { get; set; } = string.Empty;
        
    [Required]
    [MaxLength(200)]
    public string? Description { get; set; }
}