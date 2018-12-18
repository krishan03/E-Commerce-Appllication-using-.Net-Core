using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AmCart.CustomerModule
{
    public class CustomerDBContext
    {
        private readonly IMongoDatabase _database = null;

        public CustomerDBContext(IOptions<DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Customer> Customers
        {
            get
            {
                return _database.GetCollection<Customer>("Customer");
            }
        }
    }
}
