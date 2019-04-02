using AmCart.Core.Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AmCart.OrderModule.Model
{
    public class CartItem : DomainBase
    {
        public ObjectId ProductId { get; set; }

        public int Quantity { get; set; }

        public IList<TagGroup> TagGroups { get; set; }
    }
}
