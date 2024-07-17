using DTO;
using Model;

namespace Shared;

public interface IWorkingHourService
{
    public Task<WorkingHourDTO> AddHour(int hour, int minute, int seconds);
    public Task<IEnumerable<WorkingHourDTO>> GetHours();
    public Task<WorkingHourDTO> GetHour(int id);
    public Task<Response> DeleteHour(int id);
    public Task<Response> EditHour(int id, WorkingHourDTO hour);
}
