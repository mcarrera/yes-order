using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yes_orders_tests.API.Data
{
    public class OrderRepositoryTests : BaseTest, IDisposable
    {
        private OrderRepository _orderRepository;
        private AppDbContext _context;


        public OrderRepositoryTests()
        {
          
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase").Options;

            _context = new AppDbContext(options);

            var logger = Mock.Of<ILogger<OrderRepository>>();

            _orderRepository = new OrderRepository(_context, logger);
          
        }

        [Fact]
        public async Task AddOrder_ShouldAddOrderToDatabase()
        {
            // Arrange
            var order = new Order();

            // Act
            var result = await _orderRepository.AddOrder(order);

            // Assert
            Assert.Equal(order.Id, result);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted(); // Delete the in-memory database after each test
        }
    }

}
