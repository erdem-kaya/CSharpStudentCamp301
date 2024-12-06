using CSharpStudentCamp301.BusinessLayer.Abstract;
using CSharpStudentCamp301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCamp301.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerService _customerService;

        public CustomerManager(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public void TDelete(Customer entity)
        {
            _customerService.TDelete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerService.TGetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerService.TGetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" &&
               entity.CustomerName.Length >= 3 &&
               entity.CustomerCity != null &&
               entity.CustomerSurname != "" &&
               entity.CustomerSurname.Length <= 30)
            {
                _customerService.TInsert(entity);
            }
            else
            {
                return;
            }

        }

        public void TUpdate(Customer entity)
        {
            if (entity.CustomerId != 0 &&
                entity.CustomerCity != null &&
                entity.CustomerCity.Length >= 3)
            {
                _customerService.TUpdate(entity);
            } else
            {
                //throw new Exception("Customer City must be at least 3 characters");
            }
        }
    }
}
