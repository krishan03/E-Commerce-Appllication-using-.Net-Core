using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Core.Data
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public bool IsSSL { get; set; } = false;
        public IMongoDatabase database { get; }

        public MongoConnection(string connectionString, string DBName)
        {
            this.ConnectionString = connectionString;
            this.DatabaseName = DBName;
            MongoClient mongoClient = new MongoClient(connectionString);
            database = mongoClient.GetDatabase(DBName);
        }
    }
}
