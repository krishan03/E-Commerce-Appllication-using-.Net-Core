using AmCart.Core.Data;
using AmCart.Core.Data.Transaction;
using AmCart.ProductModule.Domain;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.UoW
{
   public class TagGroupUnitOfWork : MongoDBUnitOfWork<TagGroup>, ITagGroupUnitOfWork
    {
        public TagGroupUnitOfWork(IOptions<Core.Data.DBSettings> settings) :
            base(new MongoConnection(settings.Value.ConnectionString, settings.Value.Database), "TagGroup")
        {

        }
    }
}
