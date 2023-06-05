namespace CityInfoAPI.Models
{
    public class CityDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
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
