using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.Order
{
    public class TagGroup : DomainBase
    {
        public string Name { get; set; }

        public List<string> Tags { get; set; }
    }
}
