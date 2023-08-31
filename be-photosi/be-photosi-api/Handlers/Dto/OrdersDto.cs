namespace be_photosi_api.Handlers.Dto
{
    public class OrdersDto
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public AddressDto? Address { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}