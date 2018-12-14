using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IAMDbContext dbContext;

        public RoleRepository(IOptions<DBSettings> settings)
        {
            dbContext = new IAMDbContext(settings);
        }

        public async Task<Role> GetRole(string id)
        {
            try
            {
                return await dbContext.Roles.Find(u => u.Id == new ObjectId(id)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
