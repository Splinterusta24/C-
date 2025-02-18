using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        List<T> GetAllByfilter(Expression<Func<T,bool>> filter);
        T Get(Expression<Func<T, bool>> filter);
        void Update(T entity);
        void Delete(T entity);
        void Insert(T entity);        
    }
}
