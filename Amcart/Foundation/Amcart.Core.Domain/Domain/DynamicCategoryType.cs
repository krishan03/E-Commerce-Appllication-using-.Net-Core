using Amcart.Core.Domain;

namespace AmCart.Business.Core.Domain
{
    public class DynamicCategoryType : DomainBase
    {
        public string Name { get; set; }

        public bool IsExclusive { get; set; }
    }
}
