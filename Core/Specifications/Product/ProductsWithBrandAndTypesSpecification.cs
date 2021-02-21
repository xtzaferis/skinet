using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithBrandAndTypesSpecification : BaseSpecification<Product>
    {
        public ProductsWithBrandAndTypesSpecification()
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        public ProductsWithBrandAndTypesSpecification(int id) : base(product => product.Id == id)
        {
            AddInclude(product => product.ProductBrand);
            AddInclude(product => product.ProductType);
        }
    }
}