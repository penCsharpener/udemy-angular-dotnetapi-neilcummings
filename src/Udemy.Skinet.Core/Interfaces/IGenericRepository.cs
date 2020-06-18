using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Core.Interfaces {
    public interface IGenericRepository<T> where T : BaseEntity {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
    }
}
