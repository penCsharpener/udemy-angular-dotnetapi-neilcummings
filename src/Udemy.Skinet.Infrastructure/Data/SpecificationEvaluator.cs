using Microsoft.EntityFrameworkCore;
using System.Linq;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Specifications;

namespace Udemy.Skinet.Infrastructure.Data {
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec) {
            var query = inputQuery;

            if (spec.Criteria != null) {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderBy != null) {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null) {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            // needs to come after filtering and sorting or the result will be wrong
            if (spec.IsPagingEnabled) {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
