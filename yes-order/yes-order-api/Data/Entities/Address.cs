﻿namespace yes_orders_api.Data.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

    }
}