using AmCart.Core.Domain.Repository;
using AmCart.ProductModule.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.Data.Repositories
{
    public interface ITagGroupMongoDBRepository : IMongoDBRepository<TagGroup>
    {
    }
}
