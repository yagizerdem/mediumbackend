using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Services.Interface;

namespace MediumBackend.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult> ResultAsync(RegisterModel register)
        {
            var result = await _userService.RegisterAsync(register);
            return Ok(result);
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync(TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(result);
        }


    }
}
