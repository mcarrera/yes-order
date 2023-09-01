namespace be_photosi_api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid AddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

        public bool IsDeleted { get; set; }

    }
}
