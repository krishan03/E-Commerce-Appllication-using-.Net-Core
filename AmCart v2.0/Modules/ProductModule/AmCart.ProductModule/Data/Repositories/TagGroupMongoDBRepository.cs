using AmCart.Core.Data;
using AmCart.Core.Data.DataAccess;
using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.Repositories
{
    class TagGroupMongoDBRepository : MongoDBRepository<TagGroup>, ITagGroupMongoDBRepository
    {
        private MongoConnection connection;

        private string collectionName;
        public TagGroupMongoDBRepository(MongoConnection connection, string collectionName) : base(connection, collectionName)
        {

        }
    }
}
