namespace Model;

public class Client : ApplicationUser
{
    public ICollection<Appointment>? Appointments{ get; set; }
}
