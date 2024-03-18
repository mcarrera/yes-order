using Microsoft.EntityFrameworkCore;
using System.Net;
using yes_orders_api.Data.Entities;

namespace yes_order_api.Data
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasManualThroughput(600);


            modelBuilder.Entity<Address>()
              .HasNoDiscriminator()
              .ToContainer(nameof(Address))
              .HasPartitionKey(address => address.State)
              .HasKey(address => address.Id);


            modelBuilder.Entity<Category>()
            .HasNoDiscriminator()
            .ToContainer(nameof(Category))
            .HasPartitionKey(c => c.Id)
            .HasKey(address => address.Id);

            modelBuilder.Entity<Order>()
                .HasNoDiscriminator()
                .ToContainer(nameof(Order))
                .HasPartitionKey(x => x.UserId)
                .HasKey(x => x.Id);

            modelBuilder.Entity<Product>()
                .HasNoDiscriminator()
                .ToContainer(nameof(Product))
                .HasPartitionKey(x => x.CategoryId)
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
               .HasNoDiscriminator()
               .ToContainer(nameof(User))
               .HasPartitionKey(x => x.Id)
               .HasKey(x => x.Id);


        }
    }
}
