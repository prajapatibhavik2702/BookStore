using Microsoft.AspNetCore.Mvc;
using BookStore.repository;
using BookStore.models.Models;
using Microsoft.Net.Http;
namespace BookStore.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : Controller
    {
        UserRepository repository=new UserRepository();
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser()
        {
            return Ok(repository.GetUsers());
        }
      
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel login)
        {
            try {
                models.ViewModels.User user = repository.Login(login);
                if (user == null)
                {
                    return BadRequest("enter valid details");
                }
                else
                {
                    return Ok(user);
                }
            } catch (Exception ex) {
                return StatusCode(BadRequest("internal server errro").GetHashCode(),ex.Message);
            } }
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel register)
        {
            try
            {
                models.ViewModels.User user = repository.Register(register);
                if (user == null)
                {
                    return BadRequest("email already exist!");
                }
                else
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(BadRequest("internal server errror").GetHashCode(),ex.Message);
            }
        }
    }
}
