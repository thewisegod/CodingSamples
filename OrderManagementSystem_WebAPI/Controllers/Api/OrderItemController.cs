
using ErrorLogger;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OrderItemManagementSystem_WebAPI.Models;
using OrderManagementSystem_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace OrderManagementSystem_WebAPI.Controllers.Api
{
    public class OrderItemController : ApiController
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("OrderItems")]
        public IEnumerable<OrderItem> Get() => _uow.OrderItemRepository.Get();

        [HttpGet]
        [Route("OrderItems/{id}")]
        public OrderItem Get(int id) => _uow.OrderItemRepository.GetByID(id);

        [HttpPost]
        [Route("OrderItems/add")]
        public IHttpActionResult Post([FromBody] OrderItem OrderItem) =>
            Helper.Post<OrderItem>(this, _uow, _uow.OrderItemRepository, OrderItem, ModelState);

        [HttpPut]
        [Route("OrderItems/update")]
        public IHttpActionResult Put([FromBody] OrderItem OrderItem) =>
            Helper.Put<OrderItem>(this, _uow, _uow.OrderItemRepository, OrderItem, ModelState);

        [HttpDelete]
        [Route("OrderItems/delete/{id}")]
        public IHttpActionResult Delete(int id) =>
             Helper.Delete<OrderItem>(this, _uow, _uow.OrderItemRepository, id, ModelState);
    }
}
