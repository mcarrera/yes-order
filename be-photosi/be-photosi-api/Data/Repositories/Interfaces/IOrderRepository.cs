using be_photosi_api.Data.Entities;

namespace be_photosi_api.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<Guid> AddOrder(Order request);
        Task<Guid> CreateRandomOrders(int numberOfOrders);
        Task<bool> DeleteOrder(Guid id);
        Task<List<Order>> GetOrders();
    }
}
