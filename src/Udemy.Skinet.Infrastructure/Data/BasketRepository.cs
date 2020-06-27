using System;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class BasketRepository : IBasketRepository {
        public Task<bool> DeleteBasketAsync(string basketId) {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> GetBasketAsync(string basketId) {
            throw new NotImplementedException();
        }

        public Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket) {
            throw new NotImplementedException();
        }
    }
}
