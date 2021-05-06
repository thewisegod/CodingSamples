using OrderManagementSystem_MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OrderManagementSystem_MVC.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("OrderItems")]
        public IEnumerable<OrderItem> Get() => _uow.OrderItemRepository.Get();

        [HttpGet]
        [Route("OrderItems/{id}")]
        public OrderItem Get(int id) => _uow.OrderItemRepository.GetByID(id);

        //[HttpPost]
        //[Route("OrderItems/add")]
        //public IHttpActionResult Post([FromBody] OrderItem OrderItem) =>
        //    Helper.Post<OrderItem>(this, _uow, _uow.OrderItemRepository, OrderItem, ModelState);

        //[HttpPut]
        //[Route("OrderItems/update")]
        //public IHttpActionResult Put([FromBody] OrderItem OrderItem) =>
        //    Helper.Put<OrderItem>(this, _uow, _uow.OrderItemRepository, OrderItem, ModelState);

        //[HttpDelete]
        //[Route("OrderItems/delete/{id}")]
        //public IHttpActionResult Delete(int id) =>
        //     Helper.Delete<OrderItem>(this, _uow, _uow.OrderItemRepository, id, ModelState);
    }
}