using AmCart.Core.Data.Transaction;
using AmCart.Core.ExceptionManagement;
using AmCart.OrderModule.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Data.UoW
{
    public class OrderModuleUnitOfWork : UnitOfWork, IOrderModuleUnitOfWork
    {
        public OrderModuleUnitOfWork(OrderModuleDataContext dbContext, IExceptionManager exceptionManager) : base(dbContext, exceptionManager)
        {
        }
    }
}
