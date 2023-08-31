using be_photosi_api.Data.Entities;
using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Dto;
using Microsoft.EntityFrameworkCore;

namespace be_photosi_api.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(AppDbContext context, ILogger<OrderRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Guid> AddOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Adding Order ${0}", ex.ToString());
                throw;
            }
        }

        public async Task<List<Order>> GetOrders()
        {
            try
            {
               var orders = await _context.Orders
                   .Include(order => order.OrderProducts) 
                   .ThenInclude(orderProduct => orderProduct.Product)
                   .ThenInclude(product=>product.Category)
                   .Include(order=>order.User)
                   .Include(order=>order.DeliveryAddress)
                   .ToListAsync();

               return orders;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
