using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;
using Service;
using Repository;
using Data;
using AutoMapper;
using API;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

//Make the api avaliable in lan
builder.WebHost.UseUrls("http://0.0.0.0:5221");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Automapper
var mapperConfig = new MapperConfiguration(mc =>
{   mc.AddProfile(new AutoMapperProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddScoped<IGenericRepository<Category>, GenericRepository<Category>>();
builder.Services.AddScoped<IGenericRepository<Model.Service>, GenericRepository<Model.Service>>();
builder.Services.AddScoped<IGenericRepository<Image>, GenericRepository<Image>>();
builder.Services.AddScoped<IGenericRepository<WorkingHour>, GenericRepository<WorkingHour>>();
builder.Services.AddScoped<IGenericRepository<Client>, GenericRepository<Client>>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IGenericRepository<Professional>, GenericRepository<Professional>>();
builder.Services.AddScoped<IGenericRepository<Appointment>, GenericRepository<Appointment>>();
builder.Services.AddScoped<IGenericRepository<ServiceProfessionalAppointment>, GenericRepository<ServiceProfessionalAppointment>>();
builder.Services.AddScoped<IWorkingHourService, WorkingHourService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IServiceProfessionalAppointmentService, ServiceProfessionalAppointmentService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

//register appdbcontext
builder.Services.AddDbContext<AppDbCotnext>(option => 
    option.UseSqlite(builder.Configuration.GetConnectionString("sql"))
);

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbCotnext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
    options.Password.RequiredUniqueChars = 1;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseAuthorization();


app.MapControllers();

app.Run();