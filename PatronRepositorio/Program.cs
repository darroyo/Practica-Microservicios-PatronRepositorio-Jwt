using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;
using AutoMapper;
using PatronRepositorio.Dtos;
using PatronRepositorio.AutoMapperProfiles;
using PatronRepositorio.Repository.Common;
using PatronRepositorio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI
builder.Services.AddDbContext<MyDbContext>(
        options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// TODO Si quisiéramos cambiar a otras implementaciones, tocaríamos aqui
builder.Services.AddScoped<IUnitOfWork,UnitOfWorkFromBBDD>();
builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFinancialService, FinancialService>();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new AutomapperProfiles());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<MyDbContext>();
    dataContext.Database.Migrate();
}
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