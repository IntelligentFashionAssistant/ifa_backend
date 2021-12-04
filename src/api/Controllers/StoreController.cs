using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/store")]
    public class StoreController : Controller
    {
        //[HttpPost]
        //public IActionResult RateStore()
        //{
        //    return null;
        //}
        
        //[HttpGet("/{id}")]
        //public IActionResult GetStoreById()
        //{
        //    return null;
        //}
        
        [HttpGet]
        public IActionResult GetAllStores()
        {
            return null;
        }
        
        
        [HttpPost]
        public IActionResult CreateStore()
        {
            return null;
        }
        
        [HttpPut]
        public IActionResult EditStore()
        {
            return null;
        }
        
        [HttpDelete]
        public IActionResult DeleteStore()
        {
            return null;
        }
    }
}