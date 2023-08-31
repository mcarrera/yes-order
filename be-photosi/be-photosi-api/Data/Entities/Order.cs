namespace be_photosi_api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<OrderProduct> Products { get; set; }
        public Address DeliveryAddress { get; set; }
        public User User { get; set; }

    }
}
