using AmCart.Core.Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AmCart.OrderModule.Model
{
    public class Wishlist : DomainBase
    {
        public ObjectId UserId { get; set; }

        public IList<ObjectId> Products { get; set; }
    }
}
