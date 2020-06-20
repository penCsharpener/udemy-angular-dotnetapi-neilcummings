using Udemy.Skinet.Core.Entities;
using Udemy.Skinet.Core.Specifications.Params;

namespace Udemy.Skinet.Core.Specifications {
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product> {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) :
            base(ProductsWithTypesAndBrandsSpecification.GetExpression(productParams)) { }
    }
}
