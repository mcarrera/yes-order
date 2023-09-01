using MediatR;

namespace be_photosi_api.Handlers.Command
{
    public class DeleteOrderRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
