namespace DTO;

public class ClientDTO
{
    //UserInfo must prefix every Proprerty so that automapper mapps properly the inner properties of 
    //AplicationUser in Client
    public int Id { get; set; }
    public string? UserInfoUserName { get; set; }
    public string? UserInfoFirstName { get; set; }
    public string? UserInfoLastName { get; set;}
    public string? UserInfoEmail { get; set; }
    public string? UserInfoPhoneNumber { get; set; }
    public string? UserInfoBilhete { get; set; }
    public int UserInfoImageId { get; set; }
}
