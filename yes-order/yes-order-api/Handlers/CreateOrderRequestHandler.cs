﻿using yes_orders_api.Data.Entities;
using yes_orders_api.Data.Repositories.Interfaces;
using yes_orders_api.Handlers.Command;
using MediatR;

namespace yes_orders_api.Handlers
{
    public class CreateOrderRequestHandler : IRequestHandler<CreateOrderRequest, Guid>
    {
        private readonly ILogger<CreateOrderRequestHandler> _logger;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderRequestHandler(IOrderRepository orderRepository, ILogger<CreateOrderRequestHandler> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        public async Task<Guid> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var orderId = Guid.NewGuid();
                var order = new Order
                {
                    Id = orderId,
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
            catch (Exception ex)
            {
                _logger.LogError("Error in CreateOrderRequestHandler.Handle ${0} ", ex);
                throw;
            }
        }


    }
}
