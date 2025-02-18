using Project.Business.Abstract;
using Project.Data.Abstract;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete
{
    public class OrderManager:IOrderService
    {
        IOrderDal orderDal;
        public void Delete(Order entity)
        {
            orderDal.Delete(entity);
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return orderDal.Get(filter);
        }

        public List<Order> GetAll()
        {
            return orderDal.GetAll();
        }

        public List<Order> GetAllByfilter(Expression<Func<Order, bool>> filter)
        {
            return orderDal.GetAllByfilter(filter);
        }

        public void Insert(Order entity)
        {
            orderDal.Insert(entity);
        }

        public void Update(Order entity)
        {
            orderDal.Update(entity);
        }
    }
}
