using be_photosi_api.Handlers.Dto;
using MediatR;

namespace be_photosi_api.Handlers.Query
{
    public class GetOrdersQuery : IRequest<List<OrdersDto>>
    {
    }
}
