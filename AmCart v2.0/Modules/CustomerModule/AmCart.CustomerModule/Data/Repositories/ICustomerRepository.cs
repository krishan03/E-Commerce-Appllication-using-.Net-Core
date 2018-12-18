using System.Threading.Tasks;

namespace AmCart.CustomerModule
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByUserId(string id);
    }
}
