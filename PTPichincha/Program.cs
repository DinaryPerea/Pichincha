using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PTPichincha.Bussiness.Bussines;
using PTPichincha.Bussiness.Interfaces;
using PTPichincha.Domain.Utility;
using PTPichincha.Infraestructure.Persistance.Data;
using PTPichincha.Infraestructure.Persistance.Repository;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using PTPichincha.WebAPI.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Inyecar servicios para el context y controllers
builder.Services.AddControllers();
builder.Services.AddHttpClient();

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile <AutoMapperProfiles> ();
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddUnitOfWork();
builder.Services.AddServices();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
    options.EnableSensitiveDataLogging();
});

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
