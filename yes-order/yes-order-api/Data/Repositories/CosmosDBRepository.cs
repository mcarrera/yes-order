using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories;
using yes_orders_api.Data.Repositories.Interfaces;

namespace yes_order_api.Data.Repositories
{
    public class CosmosDBRepository : IOrderRepository
    {

        private readonly CosmosDbContext _context;
        private readonly ILogger<CosmosDBRepository> _logger;
        public CosmosDBRepository(CosmosDbContext cosmosDbContext, ILogger<CosmosDBRepository> logger)
        {
            _context = cosmosDbContext;
            _logger = logger;

        }
        public Task<Guid> AddOrder(Order request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrder(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Order>> GetOrders()
        {
            throw new NotImplementedException();
        }
    }
}
