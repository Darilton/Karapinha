using AutoMapper;
using DTO;
using Model;
using Shared;

namespace Service;

public class WorkingHourService : IWorkingHourService
{
    private readonly IGenericRepository<WorkingHour> repository;
    private readonly IMapper mapper;

    public WorkingHourService(IGenericRepository<WorkingHour> repository, IMapper mapper){
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<WorkingHourDTO> AddHour(int hour, int minute, int seconds)
    {
        WorkingHour newHour = await repository.InsertAsync(new WorkingHour(){
            Hour = new TimeOnly(hour, minute, seconds)
        });
        return mapper.Map<WorkingHourDTO>(newHour);
    }

    public async Task<Response> DeleteHour(int id)
    {
        WorkingHour workingHour = await repository.GetByIdAsync(id);

        if(workingHour == null)
            return Response.NOT_FOUND;
        
        await repository.DeleteByIdAsync(id);
        return Response.SUCCESS;
    }

    public async Task<Response> EditHour(int id, WorkingHourDTO hour)
    {
        WorkingHour workingHour = await repository.GetByIdAsync(id);

        if(workingHour == null)
            return Response.NOT_FOUND;
        
        workingHour.Hour = new TimeOnly(hour.HourHour, hour.HourMinute, hour.HourSecond);
        await repository.Update(workingHour);
        return Response.SUCCESS;
    }

    public async Task<WorkingHourDTO> GetHour(int id)
    {
        WorkingHour workingHour = await repository.GetByIdAsync(id);
        if(workingHour == null)
            return null!;
        
        return mapper.Map<WorkingHourDTO>(workingHour);
    }

    public async Task<IEnumerable<WorkingHourDTO>> GetHours()
    {
        IEnumerable<WorkingHour> hours = await repository.GetAllAsync();
        List<WorkingHourDTO> workingHourDTOs = new List<WorkingHourDTO>();

        foreach(WorkingHour hour in hours)
            workingHourDTOs.Add(mapper.Map<WorkingHourDTO>(hour));
        
        return workingHourDTOs;
    }
}
