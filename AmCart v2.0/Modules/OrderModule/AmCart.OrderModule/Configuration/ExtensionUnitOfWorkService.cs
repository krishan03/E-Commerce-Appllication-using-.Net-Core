using AmCart.OrderModule.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Configuration
{
    public static class ExtensionUnitOfWorkService
    {
        public static void RegisterRepositories(this IServiceCollection service)
        {
            service.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
