using System.ComponentModel.DataAnnotations;

namespace CityInfoAPI.Models
{
    public class CityDTO
    {
        
        
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string? Description { get; set; }
        
        public ICollection<PointOfInterestDTO> pointOfInterest { get; set; }
        = new List<PointOfInterestDTO>();

        public int NumberOfPointsOfInterest {
            get
            {
                return pointOfInterest.Count;
            }
        }
    }
}
