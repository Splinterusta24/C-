using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        List<Category> GetAllByfilter(Expression<Func<Category, bool>> filter);
        Category Get(Expression<Func<Category, bool>> filter);
        void Update(Category entity);
        void Delete(Category entity);
        void Insert(Category entity);
    }
}
