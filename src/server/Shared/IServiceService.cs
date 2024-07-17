using DTO;

namespace Shared;

public interface IServiceService
{
    public Task<ServiceDTO> AddService(ServiceAddDTO serviceAddDTO);
    public Task<IEnumerable<ServiceDTO>> GetServices();
    public Task<ServiceDTO> GetService(int id);
    public Task<Response> DeleteService(int id);
    public Task<Response> EditService(int id, ServiceDTO serviceDTO);
}
