using Data.Common;
using Data.Model;
using Data.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataAccess.Queries
{
    public class GetReviewsByProductIdQuery : IRequest<RequestResult<IEnumerable<ReviewModel>>>
    {
        public int ProductId { get; set; }

        public class Handler : IRequestHandler<GetReviewsByProductIdQuery, RequestResult<IEnumerable<ReviewModel>>>
        {
            private readonly IReviewRepository _reviewRepository;
            public Handler(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            }


            public async Task<RequestResult<IEnumerable<ReviewModel>>> Handle(GetReviewsByProductIdQuery request, CancellationToken cancellationToken)
            {
                if(request == null || request.ProductId <= 0)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                var result = await _reviewRepository.GetReviewsByProductId(request.ProductId).ConfigureAwait(false);
                return RequestResult.Success(result);
            }
        }
    }
}
