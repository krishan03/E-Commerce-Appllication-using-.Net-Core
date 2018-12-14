using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();

        Task<Client> GetClientAsync(string clientId);
    }
}
