using Microsoft.EntityFrameworkCore;
using System.Net;

namespace yes_order_api.Data
{
    public class CosmosDbContext : DbContext
    {
        public CosmosDbContext(DbContextOptions<CosmosDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasManualThroughput(600);
        }
    }
}
