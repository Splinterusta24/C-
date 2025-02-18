using Project.Business.Abstract;
using Project.Data.Abstract;
using Project.Data.Concrete;
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
    public class ProductManager : IProductService
    {
        IProductDal productDal = new EFProductDal();
        //private IProductDal productDal;

        //public ProductManager(IProductDal productDal)
        //{
        //    this.productDal = productDal;
        //}

        public void Delete(Product entity)
        {
            productDal.Delete(entity);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return productDal.Get(filter);
        }

        public List<Product> GetAll()
        {
            
            return productDal.GetAll();
        }

        public List<Product> GetAllByfilter(Expression<Func<Product, bool>> filter)
        {
            return productDal.GetAllByfilter(filter);
        }

        public void Insert(Product entity)
        {
            productDal.Insert(entity);
        }

        public void Update(Product entity)
        {
            productDal.Update(entity);
        }
    }
}
