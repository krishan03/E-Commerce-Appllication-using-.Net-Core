using AmCart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.CustomerModule
{
    public class CartProduct : DomainBase
    {
        public ProductLite Product { get; set; }

        public int Quantity { get; set; }

        public IList<string> DynamicCategories { get; set; }
    }
}
