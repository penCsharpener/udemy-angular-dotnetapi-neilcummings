using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Core.Interfaces {
    public interface IBasketRepository {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
