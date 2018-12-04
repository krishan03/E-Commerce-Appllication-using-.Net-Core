using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amcart.Business.Product;
using Microsoft.AspNetCore.Mvc;

namespace AmCart.Web.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Amcart.Business.Product.Product>> Get()
        {
            return await productRepository.GetAllProductsAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
