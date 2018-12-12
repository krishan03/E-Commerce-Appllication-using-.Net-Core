using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public interface IRoleRepository
    {
        Task<Role> GetRole(string id);
    }
}
