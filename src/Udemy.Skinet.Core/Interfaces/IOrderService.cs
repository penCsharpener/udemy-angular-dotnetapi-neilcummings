using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities.OrderAggregate;

namespace Udemy.Skinet.Core.Interfaces {
    public interface IOrderService {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
