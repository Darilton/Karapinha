using System.ComponentModel.DataAnnotations;

namespace DTO;

public class WorkingHourAddDTO
{
    [Range(0, 24)]
    public int Hour { get; set; }
    [Range(0,60)]
    public int Minute { get; set; }
    [Range(0,60)]
    public int Seconds { get; set; }
}
