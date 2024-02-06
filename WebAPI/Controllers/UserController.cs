using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Models.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> RegisterUser(Registration registrationModel)
        {
            var result = await userRepository.RegisterUserAsync(registrationModel);
            if (result.Success)
                return Ok(new Response() { Success = true, Message = result.Message });

            return BadRequest(new Response() { Message = result.Message, Success = false });
        }
        [HttpPost("login")]
        public async Task<ActionResult<Response>> LoginUser(Login loginModel)
        {
            var result = await userRepository.LoginUserAsync(loginModel);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

