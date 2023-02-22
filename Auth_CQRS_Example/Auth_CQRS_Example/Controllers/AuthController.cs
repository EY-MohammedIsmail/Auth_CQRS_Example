using Auth_CQRS_Example.Commands;
using Auth_CQRS_Example.Models.DTO;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auth_CQRS_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;



        public AuthController(IMediator mediator)
        {

            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("Register")]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register([FromBody] UserRegisterDto requestUser)
        //{


        //    var save_user = await _mediator.Send(new FindUserByEmail(requestUser));

        //    return Ok(save_user);

        //}
        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDto loginRequest)
        {
            var result = await _mediator.Send(new LoginRequestCommand(loginRequest));

            return Ok(result);
        }




    }
}

