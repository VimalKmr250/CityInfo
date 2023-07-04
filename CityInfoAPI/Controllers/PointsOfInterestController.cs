using CityInfoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{pointOfInterestId}",Name = "GetPointsOfInterest")]
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
            int cityId,[FromBody] PointOfInterestCreationDto pointOfInterest)
        {

             if (!ModelState.IsValid) return BadRequest();

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
        
        
        [HttpPut("{pointsofinterestid}")]
        public ActionResult<PointOfInterestDTO> CreatePointOfInterest(
            int cityId, int pointsofinterestid, [FromBody] PointOfInterestUpdateDto pointOfInterest)
        {

            if (!ModelState.IsValid) return BadRequest();

            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NoContent();

            var pointOfInterestDto = city.pointOfInterest.FirstOrDefault(item => item.Id == pointsofinterestid);
            if (pointOfInterestDto == null) return NoContent();

            pointOfInterestDto.Description = pointOfInterest.Description;
            pointOfInterestDto.Name = pointOfInterest.Name;
            
            //city.pointOfInterest.Add(pointOfInterestDto);
            //city.pointOfInterest.Where(pointOfInterest => pointOfInterestDto.Id == pointOfInterestDto.Id)
            
            return NoContent();
        }

        [HttpPatch("{pointsofinterestid}")]
        public ActionResult<PointOfInterestDTO> CreatePointOfInterest(
            int cityId, int pointsofinterestid,
            [FromBody] JsonPatchDocument<PointOfInterestUpdatePartialDto> pointOfInterestPatch)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return BadRequest();

            var pointOfInterestDto = city.pointOfInterest.FirstOrDefault(item => item.Id == pointsofinterestid);
            if (pointOfInterestDto == null) return BadRequest(); 
            
            var pointOfInterestDtotoPatch = new PointOfInterestUpdatePartialDto()
            {
                Description = pointOfInterestDto.Description,
                Name = pointOfInterestDto.Name
            };
            
            if (!ModelState.IsValid) return BadRequest(); 
            pointOfInterestPatch.ApplyTo(pointOfInterestDtotoPatch,ModelState);
           
            pointOfInterestDto.Name = pointOfInterestDtotoPatch.Name;
            pointOfInterestDto.Description = pointOfInterestDtotoPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointsofinterestid}")]
        public ActionResult<PointOfInterestDTO> DeletePointOfInterest(
            int cityId, int pointsOfInterestId)
        {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == cityId);
            if (city == null) return NotFound();

            var pointOfInterest = city.pointOfInterest.FirstOrDefault(item => item.Id == pointsOfInterestId);
            if (pointOfInterest == null) return NotFound();
            city.pointOfInterest.Remove(pointOfInterest);
            // city.pointOfInterest.ToList().RemoveAll(item => item.Id == pointsOfInterestId);
            return NoContent();
        } 
    }
}
    
