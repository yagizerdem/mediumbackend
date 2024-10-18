using Microsoft.AspNetCore.Mvc;
using Models.Entity;
using Services.Interface;
using Utility;
using Utility.CustomExceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<ActionResult> ResultAsync([FromBody] RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return BadRequest(ApiResponse<string>.Fail(errorMessages)); // Return validation errors
            }
            var result = await _userService.RegisterAsync(register);
            return Ok(ApiResponse<string>.Success(result));
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody]  TokenRequestModel model)
        {
            var result = await _userService.GetTokenAsync(model);
            return Ok(ApiResponse<AuthenticationModel>.Success(result));
        }


    }
}
