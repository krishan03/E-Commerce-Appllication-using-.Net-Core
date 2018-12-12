using Amcart.Core.Data.DataAccess;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AmCart.Business.IAM
{
    public class IAMDbContext
    {
        private readonly IMongoDatabase _database = null;

        public IAMDbContext(IOptions<DbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("User");
            }
        }

        public IMongoCollection<Client> Clients
        {
            get
            {
                return _database.GetCollection<Client>("Client");
            }
        }

        public IMongoCollection<Role> Roles
        {
            get
            {
                return _database.GetCollection<Role>("Role");
            }
        }

        public IMongoCollection<Grant> Grants
        {
            get
            {
                return _database.GetCollection<Grant>("Grant");
            }
        }

        public IMongoCollection<Permission> Permissions
        {
            get
            {
                return _database.GetCollection<Permission>("Permission");
            }
        }

    }
}