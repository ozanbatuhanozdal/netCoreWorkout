using GraphQL.Types;
using netcoregraphql.Data.Interfaces;
using netcoregraphql.Models;

namespace netcoregraphql.Data.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(ICategoryRepository categoryRepository)
        {
            Field(x=> x.Id).Description("Product id.");
            Field(x=> x.Name).Description("Product name.");
            Field(x=> x.Description, nullable: true).Description("Product description");
            Field(x=> x.Price).Description("Product price");


            Field<CategoryType>("cateogry",resolve: context=> categoryRepository.GetCategoryAsync(context.Source.CategoryId).Result);
            
        }        
        
    }
}