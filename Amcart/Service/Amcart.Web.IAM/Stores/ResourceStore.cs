using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amcart.Web.IAM.Stores
{
    public class ResourceStore : IResourceStore
    {
        public Task<ApiResource> FindApiResourceAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public Task<Resources> GetAllResourcesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
