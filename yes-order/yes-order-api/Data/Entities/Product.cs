﻿namespace yes_orders_api.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
               
    }
}