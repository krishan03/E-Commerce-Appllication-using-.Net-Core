using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.AppService.DTOs
{
    public class CartProductDTO:DtoBase
    {
        public ProductLiteDTO Product { get; set; }

        public int Quantity { get; set; }

        public IList<string> DynamicCategories { get; set; }
    }
}
