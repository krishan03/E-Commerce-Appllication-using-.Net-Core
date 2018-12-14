using AmCart.Core.Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AmCart.OrderModule
{
    public class ShortProduct : DomainBase
    {
        public ObjectId ProductId { get; set; }

        public bool InStock { get; set; }

        public string ProductName { get; set; }

        public string ShortDescription { get; set; }

        public double Price { get; set; }

        public IList<TagGroup> TagGroups { get; set; }

        public string Thumbnail { get; set; }
    }
}
