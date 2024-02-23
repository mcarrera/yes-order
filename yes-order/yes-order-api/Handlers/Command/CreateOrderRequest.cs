using yes_orders_api.Handlers.Dto;
using MediatR;

namespace yes_orders_api.Handlers.Command
{
    public class CreateOrderRequest : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public List<ProductDto> Products { get; set; }

    }
}
