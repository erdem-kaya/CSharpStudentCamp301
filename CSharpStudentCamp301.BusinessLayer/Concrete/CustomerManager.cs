using CSharpStudentCamp301.BusinessLayer.Abstract;
using CSharpStudentCamp301.DataAccessLayer.Abstract;
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
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" &&
               entity.CustomerName.Length >= 3 &&
               entity.CustomerCity != null &&
               entity.CustomerSurname != "" &&
               entity.CustomerSurname.Length <= 30)
            {
                _customerDal.Insert(entity);
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
                _customerDal.Update(entity);
            } else
            {
                //throw new Exception("Customer City must be at least 3 characters");
            }
        }
    }
}
