using Data.DataAccess.Command;
using Data.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Review.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpPost("/addUser")]
        public async Task<IActionResult> AddProduct([FromBody] User user)
        {
            var result = await _mediator.Send(new AddUserCommand { user = user });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }
    }
}
