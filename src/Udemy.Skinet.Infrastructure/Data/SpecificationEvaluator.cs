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

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}
