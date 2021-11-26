using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/property")]
    public class PropertyController : Controller
    {
        
        [HttpGet("/{id}")]
        public IActionResult GetPropertyById()
        {
            return null;
        }
        
        [HttpGet("/")]
        public IActionResult GetAllProperties()
        {
            return null;
        }
        
        
        [HttpPost("/")]
        public IActionResult CreateProperty()
        {
            return null;
        }
        
        [HttpPut("/")]
        public IActionResult EditProperty()
        {
            return null;
        }
        
        [HttpDelete("/")]
        public IActionResult DeleteProperty()
        {
            return null;
        }
    }
}