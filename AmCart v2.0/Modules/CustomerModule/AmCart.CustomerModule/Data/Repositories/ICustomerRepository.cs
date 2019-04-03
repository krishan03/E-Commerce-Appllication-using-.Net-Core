using System.Threading.Tasks;

namespace AmCart.CustomerModule
{
    public interface ICustomerRepository
    {
        Task<string> CreateAsync(Customer customer);

        Task<Customer> GetByUserId(string id);
    }
}
