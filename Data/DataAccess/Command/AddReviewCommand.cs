using Data.Common;
using Data.Model;
using Data.Repository.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using static Data.Model.ReviewForProductModel;

namespace Data.DataAccess.Command
{
    public class AddReviewCommand : IRequest<RequestResult<Unit>>
    {
        public ReviewForProductModel Review { get; set; }

        public class Handler : IRequestHandler<AddReviewCommand, RequestResult<Unit>>
        {
            private readonly IReviewRepository _reviewRepository;

            public Handler(IReviewRepository reviewRepository)
            {
                _reviewRepository = reviewRepository ?? throw new ArgumentNullException(nameof(reviewRepository));
            }

            public async Task<RequestResult<Unit>> Handle(AddReviewCommand request, CancellationToken cancellationToken)
            {
                //Null Check
                if(request.Review == null || request.Review.ProductId <= 0)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                //Check if the entered value in the score is of the same type as enum to stop the user from entering invalid records
                if(!Enum.IsDefined(typeof(ScoreValues), request.Review.Score))
                {
                    return RequestResult.Fail<Unit>(new RequestError("Invalid Score"));
                }

                await _reviewRepository.AddReviewAsync(request.Review.ToReviewModel()).ConfigureAwait(false);

                return RequestResult.Success(Unit.Value);
            }
        }
    }
}
