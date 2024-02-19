using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Command;
using MediatR;

namespace be_photosi_api.Handlers
{
    public class GenerateOrdersRequestHandlers : IRequestHandler<GenerateOrderRequest, bool>
    {

        private readonly ILogger<GenerateOrdersRequestHandlers> _logger;
        private readonly IOrderRepository _orderRepository;

        public GenerateOrdersRequestHandlers(ILogger<GenerateOrdersRequestHandlers> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<bool> Handle(GenerateOrderRequest request, CancellationToken cancellationToken)
        {

            await _orderRepository.CreateRandomOrders(request.NumberOfOrders);


            return true;
        }
    }
}
