namespace yes_orders_api.Handlers.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
    }
}