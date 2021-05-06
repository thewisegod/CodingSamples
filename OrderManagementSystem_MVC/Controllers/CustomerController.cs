
using Newtonsoft.Json;
using OrderManagementSystem_MVC.Models;
using OrderManagementSystem_MVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OrderManagementSystem_MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UnitOfWork _uow = new UnitOfWork();

        [HttpGet]
        public IEnumerable<Customer> Get() => _uow.CustomerRepository.Get();

        [HttpGet]
        public Customer Get(int id) => _uow.CustomerRepository.GetByID(id);

        [HttpGet]
        public ViewResult Post() => View();

        [HttpPost]
        public ViewResult Post(CustomerViewModel cvm)
        {
            if (cvm == null)
            {
                return View(cvm);
            }
            else
            {
                if (EntityAlreadyExists(cvm))
                {
                    cvm.Message = "Invalid Customer Add Attempt";
                    return View(cvm);
                }

                cvm.Message = Helper.Post<Customer>(_uow, _uow.CustomerRepository,
                     new Customer()
                     {
                         FirstName = cvm.FirstName,
                         LastName = cvm.LastName,
                         Phone = cvm.Phone,
                         City = cvm.City,
                         Country = cvm.Country
                     },
                     ModelState);

                return View(cvm);
            }
        }

        private bool EntityAlreadyExists(CustomerViewModel cvm) =>
            _uow.CustomerRepository.Get(_ => _.FirstName == cvm.FirstName && _.LastName == cvm.LastName && _.Phone == cvm.Phone).Any();

        //[HttpPut]
        //[Route("customers/update")]
        //public IHttpActionResult Put([FromBody] Customer customer) =>
        //    Helper.Put<Customer>(this, _uow, _uow.CustomerRepository, customer, ModelState);

        //[HttpDelete]
        //[Route("customers/delete/{id}")]
        //public IHttpActionResult Delete(int id) =>
        //     Helper.Delete<Customer>(this, _uow, _uow.CustomerRepository, id, ModelState);
    }
}