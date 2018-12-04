using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientAsync(string clientId);
    }
}
