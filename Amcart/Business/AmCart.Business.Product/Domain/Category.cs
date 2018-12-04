using Amcart.Core.Domain;
using System.Collections.Generic;

namespace Amcart.Business.Product
{
    public class Category : DomainBase
    {
        public string Name { get; set; }

        public List<Category> SubCategories { get; set; }
    }
}
