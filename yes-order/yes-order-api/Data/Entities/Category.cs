﻿namespace yes_orders_api.Data.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}
