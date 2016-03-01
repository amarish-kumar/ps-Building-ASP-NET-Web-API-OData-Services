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
        //public IHttpActionResult Get()
        //public IQueryable<Product> Get()
        public HttpResponseMessage Get()
        {
            try
            {
                var productRepository = new ProductRepository();

                //return Ok(productRepository.Retrieve().AsQueryable());
                //return productRepository.Retrieve().AsQueryable();
                return Request.CreateResponse<IQueryable<Product>>(HttpStatusCode.OK, productRepository.Retrieve().AsQueryable());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/products/5
        public HttpResponseMessage Get(int id)
        {
            try
            {
                Product product;
                var productRepository = new ProductRepository();
                if (id > 0)
                {
                    var products = productRepository.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item not found");
                    }
                }
                else
                {
                    product = productRepository.Create();
                }

                return Request.CreateResponse<Product>(HttpStatusCode.OK, product);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/products
        public HttpResponseMessage Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var productRepository = new ProductRepository();
                var newProducct = productRepository.Save(product);

                if (newProducct == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Empty shit");
                }


                var msg = Request.CreateResponse(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + newProducct.ProductId.ToString());

                return msg;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        // PUT api/products/5
        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var productRepository = new ProductRepository();
                var updateProduct = productRepository.Save(id, product);

                if (updateProduct == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product not found");
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // DELETE api/products/5
        public void Delete(int id)
        {
        }
    }
}
