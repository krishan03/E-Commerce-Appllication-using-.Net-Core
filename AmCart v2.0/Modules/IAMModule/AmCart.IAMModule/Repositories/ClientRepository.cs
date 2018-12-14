using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public class ClientRepository : IClientRepository
    {
        private readonly IAMDbContext dbContext;

        public ClientRepository(IOptions<DBSettings> settings)
        {
            dbContext = new IAMDbContext(settings);
        }

        public async Task<Client> GetClientAsync(string clientId)
        {
            try
            {
                return await dbContext.Clients.Find(document => document.Id == ObjectId.Parse(clientId)).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            try
            {
                return await dbContext.Clients.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
