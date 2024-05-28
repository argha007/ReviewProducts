using Data.Model;
using Data.Repository.Interface;
using Review.API.DatabaseConfigurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private ReviewProductDbContext _dbContext;
        public ProductRepository(ReviewProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductAsync(ProductModel product)
        {
            if(product != null)
            {
                await _dbContext.Product.AddAsync(product).ConfigureAwait(false);
                await _dbContext.SaveChangesAsync();
            }
        }

        public void UpdateProduct(ProductModel product)
        {
            if (product != null && product.Id > 0)
            {
                _dbContext.Product.Update(product);
            }
        }

        public Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return Task.FromResult(_dbContext.Product.AsEnumerable());
        }

        public Task<ProductModel> GetProductByIdAsync(int productId)
        {
            if(productId > 0)
            {
                return Task.FromResult(_dbContext.Product.First(t => t.Id == productId));
            }
            return null;
        }
    }
}
