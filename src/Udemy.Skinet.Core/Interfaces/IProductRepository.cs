using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Core.Interfaces {
    public interface IProductRepository {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}
