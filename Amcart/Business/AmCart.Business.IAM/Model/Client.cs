using Amcart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.Business.IAM
{
    public class Client : DomainBase
    {
        public string Name { get; set; }

        public string Secret { get; set; }

        public IList<string> Scopes { get; set; }
    }
}
