using Data.DataAccess.Command;
using Data.DataAccess.Queries;
using Data.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Review.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Adds New Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("/addProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            var result = await _mediator.Send(new AddProductCommand { Product = product });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }

        /// <summary>
        /// Get Product for the mentioned ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/product/{productId}")]
        public async Task<IActionResult> GetProduct(int productId)
        {
            var result = await _mediator.Send(new GetProductByIdQuery { ProductId = productId });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }


    }
}
