using Project.Data.Abstract;
using Project.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Data.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        ContextEF context = new ContextEF();
        //DbSet<T> _obj;
        //public GenericRepository()
        //{
        //    _obj = context.Set<T>();
        //}
        public void Delete(T entity)
        {
            using (ContextEF db = new ContextEF())
            {
                var deleted = db.Entry(entity);
                deleted.State = EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (ContextEF db = new ContextEF())
            {
               T result  = db.Set<T>().SingleOrDefault(filter);
               return result;
            }
        }

        public List<T> GetAll()
        {
            using (ContextEF db = new ContextEF())
            {
                return db.Set<T>().ToList();
            }
        }

        public List<T> GetAllByfilter(Expression<Func<T, bool>> filter)
        {
            using (ContextEF db = new ContextEF())
            {
                return db.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T entity)
        {
            using (ContextEF db = new ContextEF())
            {
                var deleted = db.Entry(entity);
                deleted.State = EntityState.Added;
                db.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (ContextEF db = new ContextEF())
            {
                var deleted = db.Entry(entity);
                deleted.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
