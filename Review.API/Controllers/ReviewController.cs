using System;
using System.Threading.Tasks;
using Data.DataAccess.Command;
using Data.DataAccess.Queries;
using Data.Model;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Review.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Adds New Review for the Product
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        [HttpPost("/addReview/")]
        public async Task<IActionResult> AddReview([FromBody] ReviewForProductModel review)
        {
            var result = await _mediator.Send(new AddReviewCommand { Review = review });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }

        /// <summary>
        /// Get All reviews for mentioned ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("/reviews/{productId}")]
        public async Task<IActionResult> GetReviewsByProductId(int productId)
        {
            var result = await _mediator.Send(new GetReviewsByProductIdQuery { ProductId = productId });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }

        /// <summary>
        /// Get ReviewSummary of Mentioned Product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns name="ReviewSummary"></returns>
        [HttpGet("/summary/{productId}")]
        public async Task<IActionResult> GetReviewSummaryByProductId(int productId)
        {
            var result = await _mediator.Send(new GetReviewSummaryByProductIdQuery { ProductId = productId });

            if (result.IsError)
            {
                return BadRequest(result.Error.error);
            }
            return Ok(result.GetResult());
        }
    }
}