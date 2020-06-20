using System;
using System.Linq.Expressions;
using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Extensions;
using Udemy.Skinet.Core.Specifications.Params;

namespace Udemy.Skinet.Core.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams) : base(GetExpression(productParams)) {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);

            if (productParams.Sort.HasValue()) {
                switch (productParams.Sort) {
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

        public static Expression<Func<Product, bool>> GetExpression(ProductSpecParams productParams) {
            return x => (!productParams.BrandId.HasValue || x.ProductBrandId.Equals(productParams.BrandId.Value))
                     && (!productParams.TypeId.HasValue || x.ProductTypeId.Equals(productParams.TypeId.Value));
        }
    }
}
