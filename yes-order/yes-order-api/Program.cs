using MediatR;
using System.Reflection;
using yes_orders_api.Common;
using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories;
using yes_orders_api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using yes_order_api.Data;
using System.Security.AccessControl;
using yes_order_api.Data.Repositories;

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
builder.Services.AddScoped<IOrderRepository, CosmosDBRepository>();

if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Testing")
{
    builder.Services.AddDbContext<CosmosDbContext>(optionBuilder => optionBuilder
      .UseCosmos(
              connectionString: EnvironmentVariables.GetCosmosDBConnectionString(),
              databaseName: "yes-orders",
               cosmosOptionsAction: options =>
               {
                   options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
                   options.MaxRequestsPerTcpConnection(20);
                   options.MaxTcpConnectionsPerEndpoint(32);
               }));

}
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

builder.Logging.AddConsole();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CosmosDbContext>();
    await context.Database.EnsureCreatedAsync();
}

app.UseRouting();
app.MapControllers();
app.Run();

