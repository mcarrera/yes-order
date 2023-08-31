using MediatR;
using System.Reflection;
using be_photosi_api.Common;
using Microsoft.Extensions.DependencyInjection;
using be_photosi_api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

// inject items
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(EnvironmentVariables.GetDatabaseConnection());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Logging.AddConsole();



app.UseRouting();
app.MapControllers();
app.Run();
