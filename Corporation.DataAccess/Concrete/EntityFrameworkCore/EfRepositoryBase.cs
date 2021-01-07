using Corporation.Core.Abstract;
using Corporation.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Corporation.DataAccess.Concrete.EntityFrameworkCore
{
    public class EfRepositoryBase<T, Tcontext> : IEntityRepository<T>
        where Tcontext : DbContext, new()
        where T : class, IEntity, new()
    {
        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new Tcontext())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public void Add(T entity)
        {
            using (var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new Tcontext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
