using yes_orders_api.Handlers.Dto;
using MediatR;

namespace yes_orders_api.Handlers.Query
{
    public class GetOrdersQuery : IRequest<List<OrderDto>>
    {
    }
}
