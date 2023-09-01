using be_photosi_api.Data.Entities;
using be_photosi_api.Handlers.Dto;

namespace be_photosi_api.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<Guid> AddOrder(Order request);
        Task<bool> DeleteOrder(Guid id);
        Task<List<Order>> GetOrders();
    }
}
