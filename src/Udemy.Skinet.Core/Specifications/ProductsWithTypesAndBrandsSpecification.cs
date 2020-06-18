using Udemy.Skinet.Core.Entities;

namespace Udemy.Skinet.Core.Specifications {
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product> {
        public ProductsWithTypesAndBrandsSpecification() : base() {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

    }
}
