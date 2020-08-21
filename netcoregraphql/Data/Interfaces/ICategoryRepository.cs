using System.Collections.Generic;
using System.Threading.Tasks;
using netcoregraphql.Models;

namespace netcoregraphql.Data.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> CategoriesAsync();
        Task<Category> GetCategoryAsync(int id);
    }
}