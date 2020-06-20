using System;
using System.Linq.Expressions;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Extensions;

namespace Udemy.Skinet.Core.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId) : base(GetExpression(brandId, typeId)) {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);

            if (sort.HasValue()) {
                switch (sort) {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id.Equals(id)) {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        public static Expression<Func<Product, bool>> GetExpression(int? brandId, int? typeId) {
            return x => (!brandId.HasValue || x.ProductBrandId.Equals(brandId.Value))
                     && (!typeId.HasValue || x.ProductTypeId.Equals(typeId.Value));
        }
    }
}
