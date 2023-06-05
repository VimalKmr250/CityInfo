using CityInfoAPI.Models;

namespace CityInfoAPI
{
    public class CityDataStore
    {
        public List<CityDTO> Cities { get; set; }
        public static CityDataStore Current { get; } = new CityDataStore();

        public CityDataStore()
        {
            Cities = new List<CityDTO>()
            {
                new CityDTO(){
                    Id=1,
                    Name="Chennai",
                    Description="test",
                    pointOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id=1,
                            Name="P1",
                            Description = "test",
                        },
                        new PointOfInterestDTO()
                        {
                            Id=2,
                            Name="P2",
                            Description = "test",
                        }
                    }
                },
                new CityDTO(){
                    Id=2,
                    Name="Mumbai",
                    Description="test",
                    pointOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id=3,
                            Name="P3",
                            Description = "test",
                        },
                        new PointOfInterestDTO()
                        {
                            Id=4,
                            Name="P4",
                            Description = "test",
                        }
                    }

                },
                new CityDTO(){
                    Id=3,
                    Name="Pune",
                    Description="test",
                    pointOfInterest = new List<PointOfInterestDTO>()
                    {
                        new PointOfInterestDTO()
                        {
                            Id=5,
                            Name="P5",
                            Description="Test"
                        }
                    }

                }
            };
        }
    }
}
