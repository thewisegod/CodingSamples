
using ErrorLogger;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using OrderManagementSystem_WebAPI.Models;
using SupplierManagementSystem_WebAPI.Models;
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
    public class SupplierController : ApiController
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("Suppliers")]
        public IEnumerable<Supplier> Get() => _uow.SupplierRepository.Get();

        [HttpGet]
        [Route("Suppliers/{id}")]
        public Supplier Get(int id) => _uow.SupplierRepository.GetByID(id);

        [HttpPost]
        [Route("Suppliers/add")]
        public IHttpActionResult Post([FromBody] Supplier Supplier) =>
            Helper.Post<Supplier>(this, _uow, _uow.SupplierRepository, Supplier, ModelState);

        [HttpPut]
        [Route("Suppliers/update")]
        public IHttpActionResult Put([FromBody] Supplier Supplier) =>
            Helper.Put<Supplier>(this, _uow, _uow.SupplierRepository, Supplier, ModelState);

        [HttpDelete]
        [Route("Suppliers/delete/{id}")]
        public IHttpActionResult Delete(int id) =>
             Helper.Delete<Supplier>(this, _uow, _uow.SupplierRepository, id, ModelState);
    }
}