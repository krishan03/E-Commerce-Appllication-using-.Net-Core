﻿using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AmCart.CustomerModule
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext dBContext;

        public CustomerRepository(IOptions<DBSettings> settings)
        {
            dBContext = new CustomerDBContext(settings);
        }

        public async Task<Customer> GetByUserId(string userId)
        {
            try
            {
                return await dBContext.Customers.Find(_ => _.UserId == new ObjectId(userId)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}