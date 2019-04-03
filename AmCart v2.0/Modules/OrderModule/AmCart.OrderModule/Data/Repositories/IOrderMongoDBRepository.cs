using AmCart.Core.Domain.Repository;
using AmCart.OrderModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Data.Repositories
{
    public interface IOrderMongoDBRepository : IMongoDBRepository<Order>
    {
    }
}
