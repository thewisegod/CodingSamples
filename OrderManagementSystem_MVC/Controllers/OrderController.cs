using OrderManagementSystem_MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OrderManagementSystem_MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("Orders")]
        public IEnumerable<Order> Get() => _uow.OrderRepository.Get();

        [HttpGet]
        [Route("Orders/{id}")]
        public Order Get(int id) => _uow.OrderRepository.GetByID(id);

        //[HttpPost]
        //[Route("Orders/add")]
        //public IHttpActionResult Post([FromBody] Order Order) =>
        //    Helper.Post<Order>(this, _uow, _uow.OrderRepository, Order, ModelState);

        //[HttpPut]
        //[Route("Orders/update")]
        //public IHttpActionResult Put([FromBody] Order Order) =>
        //    Helper.Put<Order>(this, _uow, _uow.OrderRepository, Order, ModelState);

        //[HttpDelete]
        //[Route("Orders/delete/{id}")]
        //public IHttpActionResult Delete(int id) =>
        //     Helper.Delete<Order>(this, _uow, _uow.OrderRepository, id, ModelState);
    }
}