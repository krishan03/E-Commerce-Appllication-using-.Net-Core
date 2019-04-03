using AmCart.Core.Data;
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

        public async Task<string> CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByUserId(string userId)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("_id", ObjectId.Parse(userId));
                return await dBContext.Customers.Find(filter).FirstOrDefaultAsync();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
