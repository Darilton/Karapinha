using DTO;
using Shared;
using Model;
using AutoMapper;

namespace Service;

public class ServiceService : IServiceService
{
    private readonly IGenericRepository<Model.Service> _repository;
    private readonly IGenericRepository<Category> category_repo;
    private readonly IMapper mapper;

    public ServiceService(IGenericRepository<Model.Service> repository, IMapper mapper, IGenericRepository<Category> category_repo){
        _repository = repository;
        this.mapper = mapper;
        this.category_repo = category_repo;
    }

    public async Task<ServiceDTO> AddService(ServiceAddDTO serviceAddDTO)
    {
        if(serviceAddDTO == null || serviceAddDTO.Price <= 0 || await category_repo.GetByIdAsync(serviceAddDTO.CategoryId) == null)
            return null!;

        Model.Service serviceToAdd = mapper.Map<Model.Service>(serviceAddDTO);
        await _repository.InsertAsync(serviceToAdd);
        return mapper.Map<ServiceDTO>(serviceToAdd);
    }

    public async Task<Response> DeleteService(int id)
    {
        Model.Service service = await _repository.GetByIdAsync(id);

        if(service == null)
           return Response.NOT_FOUND;
        
        await _repository.DeleteByIdAsync(id);
        return Response.SUCCESS;
    }

    public async Task<Response> EditService(int id, ServiceDTO serviceDTO)
    {
        Model.Service service = await _repository.GetByIdAsync(id);
        if(id != serviceDTO.Id || serviceDTO.Price <= 0 || (await category_repo.GetByIdAsync(serviceDTO.CategoryId)) == null || service == null) 
            return Response.BAD_REQUEST;
        
        service.Description = serviceDTO.Description;
        service.Name = serviceDTO.Name;
        service.Price = serviceDTO.Price;
        service.CategoryId = serviceDTO.CategoryId;
        
        await _repository.Update(service);
        return Response.SUCCESS;

    }

    public async Task<ServiceDTO> GetService(int id)
    {
        Model.Service service = await _repository.GetByIdAsync(id);

        return mapper.Map<ServiceDTO>(service);
    }

    public async Task<IEnumerable<ServiceDTO>> GetServices()
    {
        IEnumerable<Model.Service> services = await _repository.GetAllAsync();
        List<ServiceDTO> serviceDTOs = new List<ServiceDTO>();

        foreach (Model.Service service in services){
            serviceDTOs.Add(mapper.Map<ServiceDTO>(service));
        }

        return serviceDTOs;
    }
}
