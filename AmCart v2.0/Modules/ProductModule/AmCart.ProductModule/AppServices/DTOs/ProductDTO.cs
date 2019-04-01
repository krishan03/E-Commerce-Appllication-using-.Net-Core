using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.AppServices.DTOs
{
    public class ProductDTO : DtoBase
    {

        public string Name { get; set; }

        public double Price { get; set; }

        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public IList<string> Categories { get; set; }

        public IList<string> DynamicCategories { get; set; }

        public IList<TagGroupDTO> TagGroups { get; set; }

        public IList<string> ImageUrl { get; set; }

    }
}
