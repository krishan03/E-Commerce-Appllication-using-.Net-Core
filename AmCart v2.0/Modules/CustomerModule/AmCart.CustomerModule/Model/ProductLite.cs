using AmCart.Core.Domain;
using MongoDB.Bson;
using System.Collections.Generic;

namespace AmCart.CustomerModule
{
    public class ProductLite : DomainBase
    {
        public bool InStock { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public double Price { get; set; }

        public IList<TagGroup> TagGroups { get; set; }

        public string Thumbnail { get; set; }
    }
}
