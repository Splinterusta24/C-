using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        List<Customer> GetAllByfilter(Expression<Func<Customer, bool>> filter);
        Order Get(Expression<Func<Customer, bool>> filter);
        void Update(Customer entity);
        void Delete(Customer entity);
        void Insert(Customer entity);
    }
}
