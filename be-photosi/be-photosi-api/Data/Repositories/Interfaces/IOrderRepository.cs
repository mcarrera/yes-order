using be_photosi_api.Handlers.Dto;

namespace be_photosi_api.Data.Repositories.Interfaces
{
    public interface IOrderRepository
    {

        Task<Guid> AddOrder(CreateOrderRequest request);
    }
}
