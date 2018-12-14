using AmCart.Core.Domain;
using System.Collections.Generic;

namespace AmCart.IAMModule
{
    public class Client : DomainBase
    {
        public string Name { get; set; }

        public string Secret { get; set; }

        public string GrantType { get; set; }

        public IList<string> Scopes { get; set; }

        public IList<string> RedirectUris { get; set; }

        public IList<string> PostLogoutRedirectUris { get; set; }
    }
}
