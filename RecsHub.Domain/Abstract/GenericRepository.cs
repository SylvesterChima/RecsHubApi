using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RecsHub.Domain.Abstract
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : class
        // where C : IDbContext//, new()
    {
        private readonly IDbContext entities;
        public GenericRepository(IDbContext ntities)
        {
            entities = ntities;
        }
        //    private bool disposed = false;
        //    private C entities = new C();
        //    protected C Context
        //    {
        //        get { return entities; }
        //        set { entities = value; }
        //    }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = entities.Set<T>();
            return query;
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {

            entities.Set<T>().Add(entity);

        }

        public void Delete(T entity)
        {
            entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> Save(string userName, string IP)
        {
            return (await entities.SaveChanges(userName, IP) > 0);
        }

        public virtual Task<bool> Save()
        {
            return Task.FromResult((entities.SaveChanges() > 0));
        }

        //public virtual bool Save(string userName, string IP)
        //{
        //    return (entities.SaveChanges(userName, IP) > 0);
        //}

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //        if (disposing)
        //            entities.Dispose();

        //    this.disposed = true;
        //}

        public void Dispose()
        {
            // Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
