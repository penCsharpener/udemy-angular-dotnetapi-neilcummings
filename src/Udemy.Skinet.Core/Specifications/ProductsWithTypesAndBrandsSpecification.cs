using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Extensions;

namespace Udemy.Skinet.Core.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpecification(string sort) : base() {
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
    }
}
