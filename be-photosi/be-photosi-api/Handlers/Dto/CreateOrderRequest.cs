
using MediatR;

namespace be_photosi_api.Handlers.Dto
{
    public class CreateOrderRequest : IRequest<Guid>
    {
        public List<ProductDto> Products { get; set; }
      
        public Guid User { get; set; }

    }
}
