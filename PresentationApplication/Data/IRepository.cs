using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PresentationApplication.Data
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entityList);
        bool Any(Expression<Func<TEntity, bool>> predicate);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entityList);
        TEntity Find(params object[] keyValues);
        void Edit(TEntity entity);
        void EditOneAttribute(TEntity entity, Expression<Func<TEntity, object>> predicate);
        void RemoveOneAttributeFromEdit(TEntity entity, Expression<Func<TEntity, object>> predicate);

        void SaveChanges();
        void Dispose();

    }
}
