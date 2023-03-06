using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Shop.DAL.Core
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Save(TEntity[] entities);
        void Update(TEntity entity);
        void Update(TEntity[] entities);
        void Remove(TEntity entity);
        void Remove(TEntity[] entities);
        TEntity GetEntity(int id);
        List<TEntity> GetEntities();
        bool Exists(Expression<Func<TEntity, bool>> filter);
        void SaveChanges();
    }
}
