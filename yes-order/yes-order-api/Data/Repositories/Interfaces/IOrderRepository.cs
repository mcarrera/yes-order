using yes_orders_api.Data.Entities;

namespace yes_orders_api.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<Guid> AddOrder(Order request);
        Task<bool> DeleteOrder(Guid id);
        Task<List<Order>> GetOrders();
    }
}
