using be_photosi_api.Data.Entities;
using be_photosi_api.Data.Repositories.Interfaces;
using be_photosi_api.Handlers.Dto;
using Microsoft.EntityFrameworkCore;

namespace be_photosi_api.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> AddOrder(Order order)
        {
            context.Orders.Add(order);
            await context.SaveChangesAsync();

            return order.Id;
        }
    }
}
