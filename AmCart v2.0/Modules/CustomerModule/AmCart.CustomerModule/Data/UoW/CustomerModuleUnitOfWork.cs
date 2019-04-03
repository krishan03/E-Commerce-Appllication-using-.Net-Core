using AmCart.Core.Data.Transaction;
using AmCart.Core.ExceptionManagement;
using AmCart.CustomerModule.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.Data.UoW
{
    public class CustomerModuleUnitOfWork : UnitOfWork, ICustomerModuleUnitOfWork
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyProjectUnitOfWork"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        public CustomerModuleUnitOfWork(CustomerModuleDataContext dbContext, IExceptionManager exceptionManager)
            : base(dbContext, exceptionManager)
        {

        }
    }
}
