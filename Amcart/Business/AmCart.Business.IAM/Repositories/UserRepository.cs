using Amcart.Core.Data.DataAccess;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public class UserRepository : IUserRepository
    {
        private readonly IAMDbContext dbContext;

        public UserRepository(IOptions<DbSettings> settings)
        {
            dbContext = new IAMDbContext(settings);
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            try
            {
                return await dbContext.Users.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
