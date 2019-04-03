using System.Threading.Tasks;

namespace AmCart.CustomerModule
{
    public interface ICustomerRepository
    {
        Task<string> CreateAsync(Customer customer);

        Task<Customer> GetByUserId(string id);

        Task AddItemInCart(string userId, CartProduct cartProduct);

        Task AddItemInWishlist(string userId, ProductLite product);
    }
}
