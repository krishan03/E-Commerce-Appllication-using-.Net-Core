using AmCart.OrderModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.OrderModule.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetOrdersByUserId(string id);
    }
}
