using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
        List<Order> GetAllByfilter(Expression<Func<Order, bool>> filter);
        Order Get(Expression<Func<Order, bool>> filter);
        void Update(Order entity);
        void Delete(Order entity);
        void Insert(Order entity);
    }
}
