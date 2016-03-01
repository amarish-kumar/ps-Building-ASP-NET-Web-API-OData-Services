using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using APM.WebAPI.Models;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;

namespace APM.WebAPI.Controllers
{
    [ODataRouting]
    public class ProductsController : ApiController
    {
        // GET api/products
        [Queryable]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();

            return productRepository.Retrieve().AsQueryable();
        }

        /*
        public IEnumerable<Product> Get(string search)
        {
            var productRepository = new ProductRepository();

            var products = productRepository.Retrieve();

            return products.Where(p => p.ProductCode.Contains(search));
        }
        */

        // GET api/products/5
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();
            if (id > 0)
            {
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }

            return product;
        }

        // POST api/products
        public void Post([FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var newProducct = productRepository.Save(product);
        }

        [HttpPut]
        // PUT api/products/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new ProductRepository();
            var updateProduct = productRepository.Save(id, product);
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
