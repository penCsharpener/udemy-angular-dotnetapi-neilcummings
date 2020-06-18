using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class ProductRepository : IProductRepository {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context) {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync() {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id) {
            return await _context.Products.Include(p => p.ProductBrand).Include(p => p.ProductType).SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() {
            return await _context.Products.Include(p => p.ProductBrand)
                                          .Include(p => p.ProductType)
                                          .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync() {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
