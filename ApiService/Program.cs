using DriverService.Contract;
using DriverService.Model;
using DriverService.Repository;
using FactorService.Contract;
using FactorService.Model;
using FactorService.Repository;
using Microsoft.EntityFrameworkCore;
using TravelService;
using TravelService.Contract;
using TravelService.Model;
using TravelService.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<TravelDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("travel_db_context")));
builder.Services.AddDbContext<DriverDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("driver_db_context")));
builder.Services.Configure<FactorDbSetting>(
    builder.Configuration.GetSection("FactorDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITravelRepo,TravelRepo>();
builder.Services.AddScoped<ITravelerRepo,TravelerRepo>();   
builder.Services.AddScoped<IDriverRepo,DriverRepo>();
builder.Services.AddSingleton<IFactorRepo,FactorRepo>();

builder.Services.AddAutoMapper(typeof(TravelMapperConfig));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
