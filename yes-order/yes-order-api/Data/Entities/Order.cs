namespace yes_orders_api.Data.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public IList<OrderItem> Items { get; set; } = [];
        public bool IsDeleted { get; set; }

    }

    public class OrderItem
    {
        public Guid ProductId { get; set; } // Reference to the product
        public int Quantity { get; set; } // Quantity of the product in the order
    }
}
