using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Shared;
using Service;
using Repository;
using Data;
using AutoMapper;
using API;

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
builder.Services.AddScoped<IGenericRepository<WorkingHour>, GenericRepository<WorkingHour>>();
builder.Services.AddScoped<IWorkingHourService, WorkingHourService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IServiceService, ServiceService>();

//register appdbcontext
builder.Services.AddDbContext<AppDbCotnext>(option => 
    option.UseSqlite(builder.Configuration.GetConnectionString("sql"))
);

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddEntityFrameworkStores<AppDbCotnext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());


app.MapControllers();

app.Run();