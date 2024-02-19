using MediatR;

namespace be_photosi_api.Handlers.Command
{
    public class GenerateOrderRequest:IRequest<bool>
    {
        public int NumberOfOrders { get; set; }
    }
}
