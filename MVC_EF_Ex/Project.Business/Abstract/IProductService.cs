using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByfilter(Expression<Func<Product, bool>> filter);
        Product Get(Expression<Func<Product, bool>> filter);
        void Update(Product entity);
        void Delete(Product entity);
        void Insert(Product entity);
    }
}
