
using PizzaConstructor.Data.Interfaces;

namespace PizzaConstructor.Data.Infrastucture
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseRepository<T, K> : IRepository<T, K> where T : class
    {
        private bool disposed = false;

        public BaseRepository(PizzaDataContext db)
        {
            this.Context = db;
            this.DbSet = this.Context.Set<T>();
        }

        public PizzaDataContext Context { get; }

        public DbSet<T> DbSet { get; }

        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual void Delete(K id)
        {
            var item = this.DbSet.Find(id);
            this.Delete(item);
        }

        public virtual T GetById(K id)
        {
            return this.DbSet.Find(id);
        }

        public virtual IEnumerable<T> GetList(Expression<Func<T, bool>> where = null)
        {
            if (where != null)
            {
                return this.DbSet.Where(where).ToList();
            } 
            return this.DbSet.ToList();
        }

        public virtual void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
