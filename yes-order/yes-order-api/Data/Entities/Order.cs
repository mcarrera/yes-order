namespace yes_orders_api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public IList<Product> Products { get; set; } = new List<Product>();
        public bool IsDeleted { get; set; }

    }
}
