﻿using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Dto;
using be_photosi_api.Handlers.Query;
using MediatR;

namespace be_photosi_api.Handlers
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<OrderDto>>
    {

        private readonly ILogger<GetOrdersQueryHandler> _logger;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersQueryHandler(ILogger<GetOrdersQueryHandler> logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderRepository.GetOrders();
                var response = orders.Select(x => new OrderDto
                {
                    Id = x.Id,
                    Username = x.User.Username,
                    Address = new AddressDto
                    {
                        City = x.DeliveryAddress.City,
                        Country = x.DeliveryAddress.Country,
                        PostalCode = x.DeliveryAddress.PostalCode,
                        State = x.DeliveryAddress.State,
                        StreetAddress = x.DeliveryAddress.StreetAddress,
                    },
                    Products = x.OrderProducts.Select(x => new ProductDto
                    {
                        ProductId = x.ProductId,
                        Name = x.Product.Name,
                        Category = x.Product.Category.Name,
                        Quantity = x.Quantity
                    }).ToList()

                }).ToList();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error in GetOrdersQueryHandler.Handle ${0}", ex);
                throw;
            }
        }
    }
}