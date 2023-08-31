using be_photosi_api.Data.Entities;
using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Dto;
using MediatR;

namespace be_photosi_api.Handlers
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Guid>
    {

        private readonly IOrderRepository _orderRepository;

        public CreateOrderRequestHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {

            // Create an Order entity
            var orderId = Guid.NewGuid();
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                AddressId = request.AddressId,
                OrderProducts = request.Products.Select(x => new OrderProduct
                {
                    OrderId = orderId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                }).ToList()
            };
            return await _orderRepository.AddOrder(order);
        }


    }
}
