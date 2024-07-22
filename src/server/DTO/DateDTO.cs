using System.ComponentModel.DataAnnotations;

namespace DTO;

public class DateDTO
{
    [Range(0, int.MaxValue)]
    public int year {get; set;} = 0;
    [Range(0, 12)]
    public int month {get; set;} = 0;
    [Range(0,31)]
    public int day {get; set;} = 0;
}
