using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities.OrderAggregate;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Services {
    public class OrderService : IOrderService {
        public Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketId, Address shippingAddress) {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync() {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail) {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail) {
            throw new System.NotImplementedException();
        }
    }
}
