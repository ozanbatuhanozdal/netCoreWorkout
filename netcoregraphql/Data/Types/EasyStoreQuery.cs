using GraphQL.Types;
using netcoregraphql.Data.Interfaces;

namespace netcoregraphql.Data.Types
{
    public class EasyStoreQuery : ObjectGraphType
    {
        public EasyStoreQuery(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            Field<CategoryType>(
                "category",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Category id"}
                ),
                resolve: context => categoryRepository.GetCategoryAsync(context.GetArgument<int>("id")).Result
            );
 
            Field<ProductType>(
                "product",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> {Name = "id", Description = "Product id"}
                ),
                resolve: context => productRepository.GetProductAsync(context.GetArgument<int>("id")).Result
            );
        }
        
    }
}