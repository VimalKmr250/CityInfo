using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("/api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterestForCity(int cityId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            return Ok(city.pointOfInterest);
        }

        [HttpGet("{pointOfInterestId}",Name = "GetPointsOfInterestVimal")]
        public ActionResult<PointOfInterestDTO> GetPointsOfInterest(int cityId,int pointOfInterestId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            var pointOfInterest  = city.pointOfInterest
                .FirstOrDefault(c => c.Id == pointOfInterestId);
            

            if (pointOfInterest == null) return NoContent();

            return Ok(pointOfInterest);
        }

        [HttpPost]
        public ActionResult<PointOfInterestDTO> CreatePointOfInterest(
            int cityId,PointOfInterestCreationDto pointOfInterest)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            var maxPointofInterestId = CityDataStore.Current.Cities
                .SelectMany(city => city.pointOfInterest)
                .Max(p => p.Id);

            var toBeInserted = new PointOfInterestDTO()
            {
                Id = ++maxPointofInterestId,
                Name = city.Name,
                Description = city.Description,
            };
            city.pointOfInterest.Add(toBeInserted);
            
            return CreatedAtRoute(
                "GetPointsOfInterest",
                new
                {
                    //note this should be matching with the things present in the route 
                    cityId = cityId,
                    pointOfInterestId = toBeInserted.Id
                },
                toBeInserted
                ); 
        }
    }
}
