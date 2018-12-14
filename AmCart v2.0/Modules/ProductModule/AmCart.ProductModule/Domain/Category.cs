using AmCart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.ProductModule.Domain
{
    public class Category : DomainBase
    {
        public string Name { get; set; }

        public List<Category> SubCategories { get; set; }
    }
}
