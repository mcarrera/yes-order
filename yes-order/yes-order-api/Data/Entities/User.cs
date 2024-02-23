namespace yes_orders_api.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

    }
}