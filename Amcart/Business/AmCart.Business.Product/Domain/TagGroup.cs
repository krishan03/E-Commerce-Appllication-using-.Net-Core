using Amcart.Core.Domain;
using System.Collections.Generic;

namespace Amcart.Business.Product
{
    public class TagGroup : DomainBase
    {
        public string Name { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
