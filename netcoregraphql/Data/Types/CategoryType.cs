using System.Linq;
using GraphQL.Types;
using netcoregraphql.Data.Interfaces;
using netcoregraphql.Models;

namespace netcoregraphql.Data.Types
{
    public class CategoryType : ObjectGraphType<Category>
    {
        public CategoryType(IProductRepository productRepository)
        {
            Field(x=> x.Id).Description("Category Id");
            Field(x=> x.Name, nullable:true).Description("Category Name");

            Field<ListGraphType<ProductType>>(

                "products",
                resolve: context => productRepository.GetProductsWithByCategoryIdAsync(context.Source.Id).Result.ToList()
            );
            
        }
        
    }
}