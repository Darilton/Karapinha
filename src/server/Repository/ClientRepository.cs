using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Model;
using Shared;

namespace Repository;

public class ClientRepository : GenericRepository<Client>, IClientRepository
{
    private readonly AppDbCotnext db;
    public ClientRepository(AppDbCotnext db) : base(db)
    {
        this.db = db;
    }

    public async Task<IEnumerable<Client>> GetClientsWithInclude()
    {
        return await db.Clients.Include(client => client.ApplicationUser).ToListAsync();
    }

    public async Task<Client> GetClientWithInclude(int id)
    {
        Client? client = await db.Clients.Include(client => client.ApplicationUser).FirstOrDefaultAsync(client => client.Id == id);

        if(client == null) return null!;

        return client;
    }

    public override async Task DeleteByIdAsync(int id){
        Client? client = await db.Clients.Include(client => client.ApplicationUser).FirstOrDefaultAsync(client => client.Id == id);

        if (client != null){
            db.Clients.Remove(client);
            await db.SaveChangesAsync();
        }
    }
}
