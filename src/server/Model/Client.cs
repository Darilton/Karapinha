using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Model;

public class Client 
{
    private ILazyLoader lazyLoader;
    public Client(ILazyLoader lazyLoader){
        this.lazyLoader = lazyLoader;
    }
    public int Id { get; set; }
    //it's information as user
    public string? ApplicationUserId { get; set; }
    private ApplicationUser? _userInfo;
    public ApplicationUser? userInfo{ 
        get => lazyLoader.Load(this.userInfo!, ref _userInfo); 
        set => _userInfo = value; 
    }
    public ICollection<Appointment>? Appointments{ get; set; }
}
