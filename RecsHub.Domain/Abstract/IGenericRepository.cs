using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.Domain.Abstract
{
    public interface IGenericRepository<T>
    where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Dispose();
        void Edit(T entity);
        System.Linq.IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        System.Linq.IQueryable<T> GetAll();

        //bool Save();
        Task<bool> Save(string username, string Ip);
    }
}
