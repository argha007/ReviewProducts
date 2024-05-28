using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewModel>> GetReviewsByProductId(int productId);

        Task AddReviewAsync(ReviewModel review);

    }
}
