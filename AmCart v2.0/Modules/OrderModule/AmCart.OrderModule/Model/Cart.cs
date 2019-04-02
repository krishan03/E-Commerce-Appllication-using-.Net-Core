using AmCart.Core.Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AmCart.OrderModule.Model
{
    public class Cart : DomainBase
    {
        public ObjectId UserId { get; set; }

        public IList<CartItem> Items { get; set; }
    }
}
