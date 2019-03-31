using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public class UserRepository : IUserRepository
    {
        private readonly IAMDbContext dbContext;
        private readonly IRoleRepository roleRepository;

        public UserRepository(IOptions<DBSettings> settings, IRoleRepository roleRepository)
        {
            dbContext = new IAMDbContext(settings);
            this.roleRepository = roleRepository;
        }

        public async Task CreateAsync(User user)
        {
            try
            {
                var role = await roleRepository.GetRoleByName("Customer");
                user.Role = role;
                user.Permissions = new List<string>() { "Read" };
                await dbContext.Users.InsertOneAsync(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
