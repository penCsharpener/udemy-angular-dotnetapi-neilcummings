using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        public async Task<T> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync() {
            throw new NotImplementedException();
        }
    }
}
