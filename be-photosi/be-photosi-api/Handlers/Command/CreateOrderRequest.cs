using be_photosi_api.Handlers.Dto;
using MediatR;

namespace be_photosi_api.Handlers.Command
{
    public class CreateOrderRequest : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}
