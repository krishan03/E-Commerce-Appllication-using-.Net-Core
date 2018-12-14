using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public class GrantRepository : IGrantRepository
    {
        private readonly IAMDbContext dbContext;

        public GrantRepository(IOptions<DBSettings> settings)
        {
            this.dbContext = new IAMDbContext(settings);
        }

        public async Task AddAsync(Grant grant)
        {
            try
            {
                await dbContext.Grants.InsertOneAsync(grant);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Grant> GetAsync(string key)
        {
            try
            {
                return await dbContext.Grants.Find(g => g.Key == key).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IList<Grant>> GetGrantsAsync(string subjectId)
        {
            try
            {
                return await dbContext.Grants.Find(g => g.SubjectId == subjectId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            try
            {
                await dbContext.Grants.DeleteManyAsync(g => g.SubjectId == subjectId && g.ClientId == clientId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            try
            {
                await dbContext.Grants.DeleteManyAsync(g => g.SubjectId == subjectId && g.ClientId == clientId && g.Type == type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveAsync(string key)
        {
            try
            {
                await dbContext.Grants.DeleteOneAsync(g => g.Key == key);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
