
using MediatR;

namespace be_photosi_api.Handlers.Dto
{
    public class CreateOrderRequest : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public List<ProductRequest> Products { get; set; }

    }
}
