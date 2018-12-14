using Amcart.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.Business.Order
{
    public class OrderedProduct : DomainBase
    {
        public ShortProduct Product { get; set; }

        public int Quantity { get; set; }

        public IList<string> DynamicCategory { get; set; }

        public double EffectivePrice { get; set; }
    }
}
