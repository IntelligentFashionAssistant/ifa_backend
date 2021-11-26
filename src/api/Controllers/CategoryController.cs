using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/category")]
    public class CategoryController : Controller
    {
        
        [HttpGet("/{id}")]
        public IActionResult GetCategoryById()
        {
            return null;
        }
        
        [HttpGet("/")]
        public IActionResult GetAllCategories()
        {
            return null;
        }
        
        
        [HttpPost("/")]
        public IActionResult CreateCategory()
        {
            return null;
        }
        
        [HttpPut("/")]
        public IActionResult EditCategory()
        {
            return null;
        }
        
        [HttpDelete("/")]
        public IActionResult DeleteCategory()
        {
            return null;
        }
    }
}