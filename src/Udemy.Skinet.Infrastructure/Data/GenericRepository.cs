using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Interfaces;

namespace Udemy.Skinet.Infrastructure.Data {
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context) {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id) {
            throw new NotImplementedException();
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync() {
            throw new NotImplementedException();
            return await _context.Set<T>().ToListAsync();
        }
    }
}
