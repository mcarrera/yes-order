using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using yes_order_api.Data;

namespace yes_orders_api.Data.Repositories
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly SQLDbContext _context;
        private readonly ILogger<SQLOrderRepository> _logger;
        public SQLOrderRepository(SQLDbContext context, ILogger<SQLOrderRepository> logger)
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
                _logger.LogError("Error in Adding Order {0}", ex);
                throw;
            }
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
                if (order == null) return false;

                order.IsDeleted = true;
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError("Error in Deleting Order {0}", ex);
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
                    .ThenInclude(product => product.Category)
                    .Include(order => order.User)
                    .Include(order => order.Address)
                    .Where(order => !order.IsDeleted).Take(10)
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
