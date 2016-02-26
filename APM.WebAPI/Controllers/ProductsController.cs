using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using APM.WebAPI.Models;

namespace APM.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/products
        public IEnumerable<Product> Get()
        {
            var productRepository = new ProductRepository();

            return productRepository.Retrieve();
        }

        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();

            var products = productRepository.Retrieve();

            return products.Where(p => p.ProductCode.Contains(search));
        }

        // GET api/products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/products
        public void Post([FromBody]string value)
        {
        }

        // PUT api/products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
