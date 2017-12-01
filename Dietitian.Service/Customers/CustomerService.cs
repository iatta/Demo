using Dietitian.Core.Entities;
using Dietitian.Core.Exceptions;
using Dietitian.Entity.Infrastructure;
using Dietitian.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Service.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customersRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customersRepository, IUnitOfWork unitOfWork)
        {
            this.customersRepository = customersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region IGadgetService Members

        public IEnumerable<Customer> GetCustomers()
        {
            throw new DietitionException("error");
            //var customers = customersRepository.GetAll();
            //return customers;
        }

        public Customer GetCustomerbyId(int id)
        {
            var customer = customersRepository.GetById(id);
            return customer;
        }

        public void CreateCustomer(Customer customer)
        {
            customersRepository.Add(customer);
        }
        public void DeleteCustomer(int id)
        {
            var customer = customersRepository.GetById(id);
            customersRepository.Delete(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customersRepository.Update(customer);
        }

        public void SaveCustomer()
        {
            unitOfWork.Commit();
        }
        #endregion

    }
}
