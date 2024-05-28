using Data.Common;
using Data.Repository.Interface;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataAccess.Queries
{
    public class GetReviewSummaryByProductIdQuery : IRequest<RequestResult<ReviewSummary>>
    {
        public int ProductId { get; set; }

        public class Handler : IRequestHandler<GetReviewSummaryByProductIdQuery, RequestResult<ReviewSummary>>
        {
            private readonly IReviewRepository _reviewRepository;
            public Handler(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            }

            public async Task<RequestResult<ReviewSummary>> Handle(GetReviewSummaryByProductIdQuery request, CancellationToken cancellationToken)
            {
                if (request == null || request.ProductId <= 0)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var query = await _reviewRepository.GetReviewsByProductId(request.ProductId).ConfigureAwait(false);
                var recommendedCount = Convert.ToDecimal(query.Count(t => t.IsRecommended));
                var totalCount = Convert.ToDecimal(query.Count());


                var result = new ReviewSummary
                {
                    productId = request.ProductId,
                    averageScore = query.Average(t => t.Score),
                    recommendationPercentage = (recommendedCount / totalCount) * 100m
                };

                return RequestResult.Success(result);
            }
        }
    }
}
