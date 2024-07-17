namespace Shared;

public interface IGenericRepository<T> where T : class
{
    public Task<T> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<T> InsertAsync(T entity);
    public Task Update(T entity);
    public Task DeleteByIdAsync(int id);
    public Task DeleteEntity(T entity);
}
