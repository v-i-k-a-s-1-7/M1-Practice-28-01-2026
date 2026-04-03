using Microsoft.AspNetCore.Mvc;

namespace LearnJwt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("Register")]
        public IActionResult    
        {

            return Ok();
        }
    }
}
