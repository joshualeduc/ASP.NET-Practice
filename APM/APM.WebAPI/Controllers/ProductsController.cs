using APM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:57754", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        //This code is for regular get routes without odata
        //public IEnumerable<Product> Get()
        //{
        //    var productRepository = new ProductRepository();
        //    return productRepository.Retrieve();
        //}

        //public IEnumerable<Product> Get(string search)
        //{
        //    var productRepository = new ProductRepository();
        //    var products = productRepository.Retrieve();
        //    return products.Where(p => p.ProductCode.Contains(search));
        //}
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            var productRepository = new ProductRepository();

            if(id > 0)
            {
                //this is where we would query a database, if this project had one
                var products = productRepository.Retrieve();
                product = products.FirstOrDefault(p => p.ProductId == id);
            }
            else
            {
                product = productRepository.Create();
            }
            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var newProduct = productRepository.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var productRepository = new Models.ProductRepository();
            var updatedProduct = productRepository.Save(id, product);
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
