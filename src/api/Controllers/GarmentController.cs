using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/garment")]
    public class GarmentController : Controller
    {

        [HttpPost("/rate")]
        public IActionResult RateGarment()
        {
            return null;
        }
        
        
        [HttpGet("/{id:int}")]
        public IActionResult GetGarmentById()
        {
            return null;
        }
        
        
        [HttpGet("/")]
        public IActionResult GetAllGaremnts()
        {
            return null;
        }

        [HttpPost("/")]
        public IActionResult CreateGarment()
        {
            return null;
        }
        
        [HttpPut("/")]
        public IActionResult EditGarment()
        {
            return null;
        }
        
        
        [HttpDelete("/{id:int}")]
        public IActionResult DeleteGarmentById()
        {
            return null;
        }
        
        
        
    }
}