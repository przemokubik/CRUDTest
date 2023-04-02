using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PresentationApplication.Data
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.ToList();
        }
        public virtual IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = Context.Set<TEntity>().Where(predicate);
            return query.ToList();


        }


        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Any(predicate);
        }
        public virtual TEntity Find(params object[] keyValues)
        {
            TEntity query = Context.Set<TEntity>().Find(keyValues);
            return query;
        }

        public virtual void Add(TEntity entity)
        {

            Context.Set<TEntity>().Add(entity);

        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
        public virtual void DeleteRange(IEnumerable<TEntity> entityList)
        {
            Context.Set<TEntity>().RemoveRange(entityList);
        }
        public virtual void Edit(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void EditOneAttribute(TEntity entity, Expression<Func<TEntity, object>> predicate)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).Property(predicate).IsModified = true;
        }
        public virtual void RemoveOneAttributeFromEdit(TEntity entity, Expression<Func<TEntity, object>> predicate)
        {
            Context.Entry(entity).Property(predicate).IsModified = false;

        }
        public virtual void SaveChanges()
        {
            //DbInterception.Add(new CustomEFInterceptor());
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Database error: cant't save. " + ex.Message);
            }


        }

        public virtual void Dispose()
        {
            Context.Dispose();
        }

        public virtual void AddRange(IEnumerable<TEntity> entityList)
        {
            Context.Set<TEntity>().AddRange(entityList);
        }
        
    }
}