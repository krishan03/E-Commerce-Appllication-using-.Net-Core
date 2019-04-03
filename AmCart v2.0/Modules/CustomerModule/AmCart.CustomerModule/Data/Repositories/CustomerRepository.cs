using AmCart.Core.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmCart.CustomerModule
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDBContext dBContext;

        public CustomerRepository(IOptions<DBSettings> settings)
        {
            dBContext = new CustomerDBContext(settings);
        }

        public async Task<string> CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task AddItemInWishlist(string userId, ProductLite product)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("UserId", ObjectId.Parse(userId));
                var customer = await dBContext.Customers.Find(filter).FirstOrDefaultAsync();
                if (customer.Wishlist == null)
                {
                    customer.Wishlist = new List<ProductLite>();
                }

                var existingProduct = customer.Wishlist.Where(p => p.Id == product.Id).FirstOrDefault();
                if (existingProduct != null)
                {
                    customer.Wishlist.Remove(existingProduct);
                }

                customer.Wishlist.Add(product);
                await dBContext.Customers.ReplaceOneAsync(filter, customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddItemInCart(string userId, CartProduct cartProduct)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("UserId", ObjectId.Parse(userId));
                var customer = await dBContext.Customers.Find(filter).FirstOrDefaultAsync();
                if (customer.Cart == null)
                {
                    customer.Cart = new List<CartProduct>();
                }

                var existingProduct = customer.Cart.Where(p => p.Id == cartProduct.Id).FirstOrDefault();
                if (existingProduct != null)
                {
                    customer.Cart.Remove(existingProduct);
                }

                customer.Cart.Add(cartProduct);
                await dBContext.Customers.ReplaceOneAsync(filter, customer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Customer> GetByUserId(string userId)
        {
            try
            {
                var filter = Builders<Customer>.Filter.Eq("UserId", ObjectId.Parse(userId));
                return await dBContext.Customers.Find(filter).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
