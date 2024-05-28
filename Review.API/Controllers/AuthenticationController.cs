using Data.DataAccess.Security;
using Data.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Review.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("/authenticateUser")]
        public async Task<IActionResult> PostAsync([FromBody] RequestAuthUser model)
        {
            var result = await _mediator.Send(new AuthenticateService
            {
                userName = model.userName,
                password = model.password
            });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }

            return Ok(result.GetResult());
        }
    }
}
