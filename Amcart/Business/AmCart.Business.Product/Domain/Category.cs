using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.Product.Domain
{
    public class Category : DomainBase
    {
        public string Name { get; set; }

        public List<Category> SubCategories { get; set; }
    }
}
