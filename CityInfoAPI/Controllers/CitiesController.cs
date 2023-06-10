using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("/api/cities")]
    public class CitiesController: ControllerBase
    {
      [HttpGet]
      public ActionResult<IEnumerable<CityDTO>> GetCities() 
      {
            return Ok( CityDataStore.Current.Cities);
      }

      [HttpGet("{id}")]
      public ActionResult<CityDTO> GetCity(int id) 
      {
            var city = CityDataStore.Current.Cities.FirstOrDefault(item => item.Id == id);

            if (city == null ) return NoContent();
            
            return Ok(city);
      }

    }
}
