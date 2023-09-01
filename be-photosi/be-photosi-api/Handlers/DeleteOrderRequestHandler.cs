using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Command;
using MediatR;

namespace be_photosi_api.Handlers
{
    public class DeleteOrderRequestHandler : IRequestHandler<DeleteOrderRequest, bool>
    {
        private readonly ILogger<DeleteOrderRequestHandler> _logger;
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderRequestHandler(ILogger<DeleteOrderRequestHandler> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Handle(DeleteOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _orderRepository.DeleteOrder(request.Id);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in DeleteOrderRequestHandler.Handle", ex);
                throw;
            }
        }
    }
}
