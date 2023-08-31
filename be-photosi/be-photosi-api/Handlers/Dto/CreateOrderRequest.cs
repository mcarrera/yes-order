using be_photosi_api.Data.Entities;
using be_photosi_api.Dto;
using MediatR;

namespace be_photosi_api.Handlers.Dto
{
    public class CreateOrderRequest : IRequest<Guid>
    {
        public List<ProductDto> Products { get; set; }
        public AddressDto DeliveryAddress { get; set; }
        public Guid User { get; set; }

    }
}
