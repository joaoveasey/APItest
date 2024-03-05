using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "joao" && password == "12345")
            {
                var token = TokenService.GenerateToken(new APItest.Model.Employee());
                return Ok(token);
            }
            else
            {
                return BadRequest("username or password invalid");
            }
        }
    }
}