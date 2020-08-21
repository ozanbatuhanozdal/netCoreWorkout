using System.Collections.Generic;
using System.Threading.Tasks;
using netcoregraphql.Models;

namespace netcoregraphql.Data.Interfaces
{
    public interface IProductRepository
    {
              Task<List<Product>> GetProductsAsync();
         Task<List<Product>> GetProductsWithByCategoryIdAsync(int categoryId);
         Task<Product> GetProductAsync(int id);
    }
}