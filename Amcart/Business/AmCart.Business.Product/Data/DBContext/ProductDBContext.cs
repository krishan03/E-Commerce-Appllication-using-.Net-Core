using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Amcart.Business.Product
{
    public class ProductDbContext 
    {
        private readonly IMongoDatabase _database = null;


        public ProductDbContext(IOptions<DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Product");
            }
        }
    }
}
