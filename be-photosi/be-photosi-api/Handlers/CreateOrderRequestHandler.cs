using be_photosi_api.Data.Entities;
using be_photosi_api.Handlers.Dto;
using MediatR;

namespace be_photosi_api.Handlers
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest , Guid>
    {
        // todo: logging
        public Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var order = new Order
            {

            };

        }
    }
}
