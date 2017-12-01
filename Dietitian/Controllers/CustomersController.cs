using AutoMapper;
using Dietitian.Core.Entities;
using Dietitian.Core.Exceptions;
using Dietitian.Service.Customers;
using Dietitian.Web.Mappings;
using Dietitian.Web.ViewModels;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Dietitian.Web.Controllers
{

    public class CustomersController : BaseController
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [Route("All")]
        // GET: Customers
        public ActionResult Index()
        {       
           return View();
        }

        [HttpGet]
        public ActionResult GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            var entities = AutoMapperConfiguration.Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
            
            return AjaxResponse(true,entities);
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerViewModel customer)
        {
            var cust=  AutoMapperConfiguration.Mapper.Map<CustomerViewModel, Customer>(customer);
            _customerService.CreateCustomer(cust);
            _customerService.SaveCustomer();
            return AjaxResponse(true, cust);
        }


        [HttpPost]
        public ActionResult UpdateCustomer(CustomerViewModel customer)
        {
            var cust = AutoMapperConfiguration.Mapper.Map<CustomerViewModel, Customer>(customer);
            _customerService.UpdateCustomer(cust);
            _customerService.SaveCustomer();
            return AjaxResponse(true, "updated Successfully");
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            _customerService.DeleteCustomer(id);
            _customerService.SaveCustomer();
            return AjaxResponse(true, "Deleted Successfully");
        }
    }
}