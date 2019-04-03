using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.OrderModule.Data.DBContext
{
    public class OrderDbContext
    {

        private readonly IMongoDatabase _database = null;

        public OrderDbContext(IOptions<AmCart.Core.Data.DBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if(client != null)
            {
                _database = client.GetDatabase(settings.Value.Database);
            }
        }

        public IMongoCollection<Order> Orders
        {
            get
            {
                return _database.GetCollection<Order>("Order");
            }
        }
    }
}
