using AmCart.OrderModule.Data.DBContext;
using AmCart.OrderModule.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.OrderModule.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _context = null;

        public OrderRepository(IOptions<AmCart.Core.Data.DBSettings> settings)
        {
            _context = new OrderDbContext(settings);
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            try
            {
                return await _context.Orders
                    .Find(_ => true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
