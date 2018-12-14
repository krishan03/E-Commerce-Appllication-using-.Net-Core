using AmCart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.ProductModule.Domain
{
    public class TagGroup : DomainBase
    {
        public string Name { get; set; }

        public List<string> Tags { get; set; }
    }
}
