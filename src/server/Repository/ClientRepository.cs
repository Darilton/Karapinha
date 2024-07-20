using Data;
using Microsoft.EntityFrameworkCore;
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
        return await db.Clients.Include(client => client.userInfo).ToListAsync();
    }

    public async Task<Client> GetClientWithInclude(int id)
    {
        Client? client = await db.Clients.Include(client => client.userInfo).FirstOrDefaultAsync(client => client.Id == id);

        if(client == null) return null!;

        return client;
    }
}
