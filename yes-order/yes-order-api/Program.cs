using MediatR;
using System.Reflection;
using yes_orders_api.Common;
using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories;
using yes_orders_api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers().AddFluentValidation(s =>
{
    s.ImplicitlyValidateChildProperties = true;
    s.ImplicitlyValidateRootCollectionElements = true;
    s.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

// inject items
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Testing")
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite("Data Source=yes-order.db");
    });
}
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

builder.Logging.AddConsole();



app.UseRouting();
app.MapControllers();
app.Run();

