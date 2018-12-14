using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public class UserRepository : IUserRepository
    {
        private readonly IAMDbContext dbContext;

        public UserRepository(IOptions<DBSettings> settings)
        {
            dbContext = new IAMDbContext(settings);
        }

        public async Task<User> GetUserAsync(string id)
        {
            try
            {
                return await dbContext.Users.Find(u => u.Id == new ObjectId(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await dbContext.Users.Find(u => u.Username == username).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            try
            {
                return await dbContext.Users.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
