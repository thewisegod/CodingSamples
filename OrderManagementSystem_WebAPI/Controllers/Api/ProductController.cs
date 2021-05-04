using OrderManagementSystem_WebAPI.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace OrderManagementSystem_WebAPI.Controllers.Api
{
    public class ProductController : ApiController
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("Products")]
        public IEnumerable<Product> Get() => _uow.ProductRepository.Get();

        [HttpGet]
        [Route("Products/{id}")]
        public Product Get(int id) => _uow.ProductRepository.GetByID(id);

        [HttpPost]
        [Route("Products/add")]
        public IHttpActionResult Post([FromBody] Product Product) =>
            Helper.Post<Product>(this, _uow, _uow.ProductRepository, Product, ModelState);

        [HttpPut]
        [Route("Products/update")]
        public IHttpActionResult Put([FromBody] Product Product) =>
            Helper.Put<Product>(this, _uow, _uow.ProductRepository, Product, ModelState);

        [HttpDelete]
        [Route("Products/delete/{id}")]
        public IHttpActionResult Delete(int id) =>
             Helper.Delete<Product>(this, _uow, _uow.ProductRepository, id, ModelState);
    }
}