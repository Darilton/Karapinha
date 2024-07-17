using Shared;
using Model;
using DTO;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _repository;

    public CategoryService(IGenericRepository<Category> _repository){
        this._repository = _repository;
    }

    public async Task<CategoryDTO> AddCategory(string categoryName)
    {
        Category newCategory = new Category(){
            Name = categoryName
        };

        newCategory = await _repository.InsertAsync(newCategory);

        return new CategoryDTO(){
            Name = newCategory.Name,
            Id = newCategory.Id
        };
    }

    public async Task<Response> DeleteCategory(int id)
    {
        if(await _repository.GetByIdAsync(id) == null)
            return Response.NOT_FOUND;
        
        await _repository.DeleteByIdAsync(id);

        return Response.SUCCESS;
    }

    public async Task<Response> EditCategory(int id, CategoryDTO updatedCategory)
    {
        Category category = await _repository.GetByIdAsync(id);
        if(category == null)
            return Response.NOT_FOUND;
        
        category.Name = updatedCategory.Name;
        await _repository.Update(category);

        return Response.SUCCESS;

    }

    public async Task<IEnumerable<CategoryDTO>> GetCategories()
    {
        var Categories = await _repository.GetAllAsync();
        List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();

        foreach (var category in Categories){
            categoryDTOs.Add(new CategoryDTO(){
                Name = category.Name,
                Id = category.Id
            });
        }

        return categoryDTOs;
    }

    public async Task<CategoryDTO> GetCategory(int id){
        Category category = await _repository.GetByIdAsync(id);

        if(category == null)
            return null!;
        
        return new CategoryDTO(){
            Name = category.Name,
            Id = category.Id
        };
    }
}
