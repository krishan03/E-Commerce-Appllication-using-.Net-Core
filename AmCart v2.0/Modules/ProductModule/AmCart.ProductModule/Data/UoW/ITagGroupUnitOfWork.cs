using AmCart.Core.Data.Transaction;
using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.UoW
{
    public  interface ITagGroupUnitOfWork :IMongoDBUnitOfWork<TagGroup>
    {
    }
}
