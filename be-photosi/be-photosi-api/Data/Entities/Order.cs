namespace be_photosi_api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public IEnumerable<Product> Products { get; set; } = new List<Product>();
        public Address DeliveryAddress { get; set; }
        public User User { get; set; }

    }
}
