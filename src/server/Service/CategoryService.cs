using Shared;
using Model;
using DTO;
using AutoMapper;

namespace Service;

public class CategoryService : ICategoryService
{
    private readonly IGenericRepository<Category> _repository;
    private readonly IMapper mapper;

    public CategoryService(IGenericRepository<Category> _repository, IMapper mapper){
        this._repository = _repository;
        this.mapper = mapper;
    }

    public async Task<CategoryDTO> AddCategory(string categoryName)
    {
        Category newCategory = new Category(){
            Name = categoryName
        };

        newCategory = await _repository.InsertAsync(newCategory);

        return mapper.Map<CategoryDTO>(newCategory);
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
            categoryDTOs.Add(mapper.Map<CategoryDTO>(category));
        }

        return categoryDTOs;
    }

    public async Task<CategoryDTO> GetCategory(int id){
        Category category = await _repository.GetByIdAsync(id);

        if(category == null)
            return null!;
        
        return mapper.Map<CategoryDTO>(category);
    }

    public async Task<IEnumerable<ServiceDTO>> GetCategoryServices(int id)
    {
        Category category = await _repository.GetByIdAsync(id);

        if(category == null) return null!;

        return mapper.Map<IEnumerable<ServiceDTO>>(category.Services);
    }
}
