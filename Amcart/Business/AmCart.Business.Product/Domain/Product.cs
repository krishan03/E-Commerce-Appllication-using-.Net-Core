using Amcart.Core.Domain;
using System.Collections.Generic;

namespace Amcart.Business.Product
{
    public class Product : DomainBase
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public IList<string> Categories { get; set; }

        public IList<string> DynamicCategories { get; set; }

        public IList<TagGroup> TagGroups { get; set; }
    }
}
