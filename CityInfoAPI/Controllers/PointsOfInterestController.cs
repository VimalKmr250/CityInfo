using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("/api/cities/{cityId}/pointsofinterest")]
    public class PointsOfInterestController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterest(int cityId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            return Ok(city.pointOfInterest);
        }

        [HttpGet("{pointOfInterestId}")]
        public ActionResult<IEnumerable<PointOfInterestDTO>> GetPointsOfInterest(int cityId,int pointOfInterestId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            var pointOfInterest  = city.pointOfInterest
                .FirstOrDefault(c => c.Id == pointOfInterestId);

            if (pointOfInterest == null) return NoContent();

            return Ok(pointOfInterest);
        }
    }
}
