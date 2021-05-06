using OrderManagementSystem_MVC.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OrderManagementSystem_MVC.Controllers
{
    public class SupplierController : Controller
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        [Route("Suppliers")]
        public IEnumerable<Supplier> Get() => _uow.SupplierRepository.Get();

        [HttpGet]
        [Route("Suppliers/{id}")]
        public Supplier Get(int id) => _uow.SupplierRepository.GetByID(id);

        //[HttpPost]
        //[Route("Suppliers/add")]
        //public IHttpActionResult Post([FromBody] Supplier Supplier) =>
        //    Helper.Post<Supplier>(this, _uow, _uow.SupplierRepository, Supplier, ModelState);

        //[HttpPut]
        //[Route("Suppliers/update")]
        //public IHttpActionResult Put([FromBody] Supplier Supplier) =>
        //    Helper.Put<Supplier>(this, _uow, _uow.SupplierRepository, Supplier, ModelState);

        //[HttpDelete]
        //[Route("Suppliers/delete/{id}")]
        //public IHttpActionResult Delete(int id) =>
        //     Helper.Delete<Supplier>(this, _uow, _uow.SupplierRepository, id, ModelState);
    }
}