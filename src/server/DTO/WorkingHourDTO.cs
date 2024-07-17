namespace DTO;

public class WorkingHourDTO
{
    public int Id { get; set; }

    //Hour before every atribute is needed by the automapper to convert entity Timeonly property in WorkingHour
    public int HourHour { get; set; }
    public int HourMinute { get; set; }
    public int HourSecond { get; set; }
}
