using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.CustomerModule.AppService.DTOs
{
    public class ProductLiteDTO: DtoBase
    {
        public bool InStock { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public double Price { get; set; }

        public IList<TagGroupDTO> TagGroups { get; set; }

        public string Thumbnail { get; set; }

        public List<string> ImageUrl { get; set; }
    }
}
