using Project.Business.Abstract;
using Project.Data.Abstract;
using Project.Data.EntityFramewor;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal categoryDal = new EFCategoryDal();
        public void Delete(Category entity)
        {
            categoryDal.Delete(entity);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return categoryDal.Get(filter);
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll();
        }

        public List<Category> GetAllByfilter(Expression<Func<Category, bool>> filter)
        {
            return categoryDal.GetAllByfilter(filter);
        }

        public void Insert(Category entity)
        {
            categoryDal.Insert(entity);
        }

        public void Update(Category entity)
        {
            categoryDal.Update(entity);
        }
    }
}
