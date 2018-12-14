using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.Customer
{
    public class TagGroup : DomainBase
    {
        public string Name { get; set; }

        public List<string> Tags { get; set; }
    }
}
