using Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository.Interface
{
    public interface IProductRepository
    {
        Task<ProductModel> GetProductByIdAsync(int productId);

        Task<IEnumerable<ProductModel>> GetAllProductsAsync(); 

        Task AddProductAsync(ProductModel product);

        void UpdateProduct(ProductModel product);
    }
}
