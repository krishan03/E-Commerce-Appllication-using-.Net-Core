using AmCart.Core.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.Data.Repositories
{
    public interface INewCustomerRepository: IMongoDBRepository<Customer>
    {
    }
}
