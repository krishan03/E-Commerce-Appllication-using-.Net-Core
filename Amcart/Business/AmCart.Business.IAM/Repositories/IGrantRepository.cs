using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public interface IGrantRepository
    {
        Task<IList<Grant>> GetGrantsAsync(string subjectId);

        Task<Grant> GetAsync(string key);

        Task RemoveAllAsync(string subjectId, string clientId);

        Task RemoveAllAsync(string subjectId, string clientId, string type);

        Task RemoveAsync(string key);

        Task AddAsync(Grant grant);
    }
}
