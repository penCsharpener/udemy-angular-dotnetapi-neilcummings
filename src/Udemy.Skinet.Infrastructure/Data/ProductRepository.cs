using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class ProductRepository : IProductRepository {
        public async Task<Product> GetProductByIdAsync(int id) {
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync() {
        }
    }
}
