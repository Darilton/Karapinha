using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Data;

public class AppDbCotnext: IdentityDbContext<ApplicationUser>
{
    public AppDbCotnext(DbContextOptions<AppDbCotnext> options) : base(options) { }
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Service> Services{ get; set; }
    public DbSet<Image> Images{ get; set; }
    public DbSet<Appointment> Appointments{ get; set; }
    public DbSet<ServiceProfessionalAppointment> ServiceProfessionalAppointments{ get; set; }
    public DbSet<WorkingHour> workingHours{ get; set; }
    public DbSet<Client> Clients{ get; set; }
    public DbSet<Professional> Professionals{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Client>().Navigation(e => e.ApplicationUser).AutoInclude();
        base.OnModelCreating(modelBuilder);
    }
}
