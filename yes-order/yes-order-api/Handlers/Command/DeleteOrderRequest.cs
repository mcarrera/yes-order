using MediatR;

namespace yes_orders_api.Handlers.Command
{
    public class DeleteOrderRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
