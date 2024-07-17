using Model;
using DTO;

namespace Shared;

public interface ICategoryService
{
    public Task<CategoryDTO> AddCategory(string categoryName);
    public Task<IEnumerable<CategoryDTO>> GetCategories();
    public Task<CategoryDTO> GetCategory(int id);
    public Task<Response> DeleteCategory(int id);
    public Task<Response> EditCategory(int id, CategoryDTO updatedCategory);
}
