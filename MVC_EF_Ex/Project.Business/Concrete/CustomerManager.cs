using Project.Business.Abstract;
using Project.Data.Abstract;
using Project.Data.EntityFramework;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal customerDal = new EFCustomerDal();
        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers =  customerDal.GetAll();
            return customers;
        }

        public List<Customer> GetAllByfilter(Expression<Func<Customer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
