using Amcart.Business.Data.DBContext;
using Amcart.Core.Data.Transaction;
using Amcart.Core.ExceptionManagement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amcart.Business.UoW
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
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
        public ApplicationUnitOfWork(ApplicationDbContext dbContext, IExceptionManager exceptionManager)
            : base(dbContext, exceptionManager)
        {
            //ServiceProvider = serviceProvider;
        }

        ///// <summary>
        ///// BookRepository holder
        ///// </summary>
        //private ProductRepository productRepository;

        ///// <summary>
        ///// Gets the BookRepository repository.
        ///// </summary>
        ///// <value>
        ///// The BookRepository repository.
        ///// </value>
        //IProductRepository IApplicationUnitOfWork.ProductRepository
        //{
        //    get
        //    {
        //        return ServiceProvider.GetService<IProductRepository>();
        //    }
        //}
    }
}
