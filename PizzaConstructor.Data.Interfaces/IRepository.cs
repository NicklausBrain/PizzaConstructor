
namespace PizzaConstructor.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T, K> : IDisposable where T : class
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity); 

        void Delete(K id);

        T GetById(K id);

        IEnumerable<T> GetList(Expression<Func<T, bool>> where = null);

        void SaveChanges();
    }
}
