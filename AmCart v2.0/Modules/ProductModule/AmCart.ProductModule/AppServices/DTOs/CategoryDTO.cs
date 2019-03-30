using AmCart.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmCart.ProductModule.AppServices.DTOs
{
    public class CategoryDTO:DtoBase
    {
        public string Name { get; set; }

        public List<CategoryDTO> SubCategories { get; set; }
    }
}
