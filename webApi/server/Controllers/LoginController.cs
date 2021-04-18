using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Domain.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost(Name = "Login")]
        public void Create([FromBody] LoginForm loginForm)
        {
            _userService.CheckCredentials(loginForm);
        }
    }
}
