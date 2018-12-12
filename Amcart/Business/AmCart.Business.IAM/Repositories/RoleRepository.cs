using Amcart.Core.Data.DataAccess;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IAMDbContext dbContext;

        public RoleRepository(IOptions<DbSettings> settings)
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
