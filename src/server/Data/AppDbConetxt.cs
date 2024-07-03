using Microsoft.EntityFrameworkCore;
using Model;

namespace Data;

public class AppDbCotnext: DbContext
{
    public AppDbCotnext(DbContextOptions<AppDbCotnext> options) : base(options) { }
    public DbSet<Category> Categories{ get; set; }
    public DbSet<Service> Services{ get; set; }
}
