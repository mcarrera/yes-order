namespace yes_orders_api.Handlers.Dto
{
    public class AddressDto
    {
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set;}
        public string? Country { get; set; }
        public Guid Id { get; internal set; }
    }
}