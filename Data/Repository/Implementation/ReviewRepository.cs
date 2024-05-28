using Data.Model;
using Data.Repository.Interface;
using Review.API.DatabaseConfigurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class ReviewRepository : IReviewRepository
    {
        private ReviewProductDbContext _dbContext;
        public ReviewRepository(ReviewProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddReviewAsync(ReviewModel review)
        {
            if(review != null)
            {
                await _dbContext.Review.AddAsync(review).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public Task<IEnumerable<ReviewModel>> GetReviewsByProductId(int productId)
        {
            return Task.FromResult(_dbContext.Review.Where(t => t.ProductId == productId).AsEnumerable());
        }
    }
}
