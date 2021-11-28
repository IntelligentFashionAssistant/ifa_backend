using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    // TODO : add global prefix : /api/v-x
    [Route("/user")]
    public class UserController : Controller 
    {
        [HttpPost("/search")]
        public IActionResult SearchUsers()
        {
            // return list of matched users
            return null; 
        }
        
        // TODO : move to authentication controller 
        [HttpPost("/login")]
        public IActionResult Login()
        {
            return null; 
        }
        
        
        //*************************************** CRUD ************************************// 
        [HttpGet("/{id}")]
        public IActionResult GetUserById()
        {
            return null;
        }
        
        [HttpGet("/")]
        public IActionResult GetAllUsers()
        {
            return null;
        }

        /// <summary>
        /// create new user on register 
        /// </summary>
        /// <returns></returns>
        [HttpPost("/")]
        public IActionResult CreateUser()
        {
            return null; 
        }

        [HttpPut("/")]
        public IActionResult EditUser()
        {
            return null;
        }
        
        [HttpDelete("/{id}")]
        public IActionResult DeleteUser()
        {
            return null;
        }
    }
}