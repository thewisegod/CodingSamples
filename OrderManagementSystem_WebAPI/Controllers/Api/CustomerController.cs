
using ErrorLogger;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
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
    public class CustomerController : ApiController
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("customers")]
        public IEnumerable<Customer> Get() => _uow.CustomerRepository.Get();

        [HttpGet]
        [Route("customers/{id}")]
        public Customer Get(int id) => _uow.CustomerRepository.GetByID(id);

        [HttpPost]
        [Route("customers/add")]
        public IHttpActionResult Post([FromBody] Customer customer)
        {
            if (EntityAlreadyExists(customer))
            {
                return BadRequest("The Customer that you are attempting to add already exists");
            }

            return Helper.Post<Customer>(this, _uow, _uow.CustomerRepository, customer, ModelState);
        }

        private bool EntityAlreadyExists(Customer customer) =>
            _uow.CustomerRepository.Get(_ => _.FirstName == customer.FirstName && _.LastName == customer.LastName && _.Phone == customer.Phone).Any();

        [HttpPut]
        [Route("customers/update")]
        public IHttpActionResult Put([FromBody] Customer customer) =>
            Helper.Put<Customer>(this, _uow, _uow.CustomerRepository, customer, ModelState);

        [HttpDelete]
        [Route("customers/delete/{id}")]
        public IHttpActionResult Delete(int id) =>
             Helper.Delete<Customer>(this, _uow, _uow.CustomerRepository, id, ModelState);
    }
}