using System.Threading.Tasks;

namespace AmCart.IAMModule
{
    public interface IRoleRepository
    {
        Task<Role> GetRole(string id);
    }
}
