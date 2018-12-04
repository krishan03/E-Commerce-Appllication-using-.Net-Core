using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmCart.Business.IAM
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
