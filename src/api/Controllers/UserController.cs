//using Microsoft.AspNetCore.Mvc;

//namespace api.Controllers
//{
//    [ApiController]
//    // TODO : add global prefix : /api/v-x
//    [Route("/user")]
//    public class UserController : Controller 
//    {
//        [HttpPost]
//        public IActionResult SearchUsers()
//        {
//            // return list of matched users
//            return null; 
//        }
        
//        // TODO : move to authentication controller 
//        [HttpPost]
//        public IActionResult Login()
//        {
//            return null; 
//        }
        
        
//        //*************************************** CRUD ************************************// 
//        //[HttpGet("/{id}")]
//        //public IActionResult GetUserById()
//        //{
//        //    return null;
//        //}
        
//        [HttpGet]
//        public IActionResult GetAllUsers()
//        {
//            return null;
//        }

//        /// <summary>
//        /// create new user on register 
//        /// </summary>
//        /// <returns></returns>
//        [HttpPost]
//        public IActionResult CreateUser()
//        {
//            return null; 
//        }

//        [HttpPut]
//        public IActionResult EditUser()
//        {
//            return null;
//        }
        
//        [HttpDelete]
//        public IActionResult DeleteUser(long id)
//        {
//            return null;
//        }
//    }
//}