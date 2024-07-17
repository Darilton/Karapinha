using Shared;
using Data;
using Microsoft.EntityFrameworkCore;
namespace Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbCotnext db;
    private readonly DbSet<T> dbSet;

    public GenericRepository(AppDbCotnext db){
        this.db = db;
        dbSet = db.Set<T>();
    }
    public async Task DeleteByIdAsync(int id)
    {
        T? entity = await dbSet.FindAsync(id);

        if (entity != null){
            dbSet.Remove(entity);
            await db.SaveChangesAsync();
        }
    }

    public Task DeleteEntity(T entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        T? entity = await dbSet.FindAsync(id);

        return entity!;
    }

    public async Task<T> InsertAsync(T entity)
    {
        dbSet.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
