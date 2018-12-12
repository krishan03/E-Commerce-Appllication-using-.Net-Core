using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amcart.Web.IAM
{
    public class ResourceStore : IResourceStore
    {
        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var resources = GetApiResources();
            return resources.Where(r => r.Name == name).FirstOrDefault();
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var resources = GetApiResources();
            return resources.Where(r => scopeNames.Contains(r.Name));
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var resources = GetIdentityResources();
            return resources.Where(r => scopeNames.Contains(r.Name));
        }

        public IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource { Name = "custom", UserClaims = new List<string> { "custom" } }
            };
        }

        private IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>();
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            return new Resources(GetIdentityResources(), GetApiResources());
        }
    }
}
