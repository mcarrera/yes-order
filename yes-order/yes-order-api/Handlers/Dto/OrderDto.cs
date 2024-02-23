namespace yes_orders_api.Handlers.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public Guid UserId { get; set; }
        public AddressDto? DeliverAddress { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}