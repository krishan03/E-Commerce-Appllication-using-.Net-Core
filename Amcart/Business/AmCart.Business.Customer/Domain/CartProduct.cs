using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.Customer
{
    public class CartProduct : DomainBase
    {
        public ShortProduct Product { get; set; }

        public int Quantity { get; set; }

        public IList<string> DynamicCategories { get; set; }
    }
}
