
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
        public ViewResult Get()
        {
            var cvmList = new List<CustomerViewModel>();
            var customers = _uow.CustomerRepository.Get();
            foreach (var customer in customers)
            {
                cvmList.Add(Helper.CopyModelToViewModel<Customer, CustomerViewModel>(customer));
            }
            return View(cvmList);
        }

        public ViewResult Details(int id) => LoadViewById(id, "Details");

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
                if (CustomerAlreadyExists(cvm))
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

        private bool CustomerAlreadyExists(CustomerViewModel cvm) =>
            _uow.CustomerRepository.Get(_ => _.FirstName == cvm.FirstName && _.LastName == cvm.LastName && _.Phone == cvm.Phone).Any();

        [HttpGet]
        public ViewResult Put(int id) => LoadViewById(id, "Put");

        [HttpPut]
        public ViewResult Put(CustomerViewModel cvm)
        {
            if (cvm == null)
            {
                return View(cvm);
            }
            else
            {
                cvm.Message = Helper.Put<Customer>(_uow, _uow.CustomerRepository,
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

        [HttpDelete]
        public ViewResult Delete(int id)
        {
            var cvm = new CustomerViewModel()
            {
                Message = Helper.Delete<Customer>(_uow, _uow.CustomerRepository, id, ModelState)
            };

            return View(cvm);
        }

        private ViewResult LoadViewById(int id, string view)
        {
            var customer = _uow.CustomerRepository.GetByID(id);
            var cvm = Helper.CopyModelToViewModel<Customer, CustomerViewModel>(customer);
            return View(view, cvm);
        }
    }
}