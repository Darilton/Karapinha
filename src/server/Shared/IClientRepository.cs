using Model;

namespace Shared;

public interface IClientRepository : IGenericRepository<Client>
{
    public Task<Client> GetClientWithInclude(int id);
    public Task<IEnumerable<Client>> GetClientsWithInclude();
}
