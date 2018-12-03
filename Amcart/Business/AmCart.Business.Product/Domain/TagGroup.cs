using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.Product.Domain
{
    public class TagGroup : DomainBase
    {
        public string Name { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
