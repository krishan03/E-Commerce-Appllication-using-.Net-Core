using AmCart.Business.IAM;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amcart.Web.IAM
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        protected IGrantRepository repository;

        public PersistedGrantStore(IGrantRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<PersistedGrant>> GetAllAsync(string subjectId)
        {
            var grants = await repository.GetGrantsAsync(subjectId);
            var persistedGrants = new List<PersistedGrant>();
            foreach (var grant in grants)
            {
                persistedGrants.Add(new PersistedGrant()
                {
                    ClientId = grant.ClientId,
                    CreationTime = grant.CreationTime,
                    Data = grant.Data,
                    Expiration = grant.Expiration,
                    Key = grant.Key,
                    SubjectId = grant.SubjectId,
                    Type = grant.Type
                });
            }

            return persistedGrants;
        }

        public async Task<PersistedGrant> GetAsync(string key)
        {
            var grant = await repository.GetAsync(key);
            return new PersistedGrant()
            {
                ClientId = grant.ClientId,
                CreationTime = grant.CreationTime,
                Data = grant.Data,
                Expiration = grant.Expiration,
                Key = grant.Key,
                SubjectId = grant.SubjectId,
                Type = grant.Type
            };
        }

        public async Task RemoveAllAsync(string subjectId, string clientId)
        {
            await repository.RemoveAllAsync(subjectId, clientId);
        }

        public async Task RemoveAllAsync(string subjectId, string clientId, string type)
        {
            await repository.RemoveAllAsync(subjectId, clientId, type);
        }

        public async Task RemoveAsync(string key)
        {
            await repository.RemoveAsync(key);
        }

        public async Task StoreAsync(PersistedGrant persistedGrant)
        {
            var grant = new Grant()
            {
                ClientId = persistedGrant.ClientId,
                CreationTime = persistedGrant.CreationTime,
                Data = persistedGrant.Data,
                Expiration = persistedGrant.Expiration,
                Key = persistedGrant.Key,
                SubjectId = persistedGrant.SubjectId,
                Type = persistedGrant.Type
            };
            await repository.AddAsync(grant);
        }
    }
}
