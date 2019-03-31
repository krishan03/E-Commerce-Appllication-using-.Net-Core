using AmCart.Core.Data;
using AmCart.ProductModule.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AmCart.ProductModule.Data.DBContext
{
    public class ProductDbContext
    {
        private readonly IMongoDatabase _database = null;


        public ProductDbContext(IOptions<AmCart.Core.Data.DBSettings> settings)
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

        public IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>("Category");
            }
        }

        public IMongoCollection<TagGroup> TagGroup
        {
            get
            {
                return _database.GetCollection<TagGroup>("TagGroup");
            }
        }
    }
}
