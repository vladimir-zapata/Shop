using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DAL.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ShopContext context;
        private DbSet<TEntity> myEntity;

        public RepositoryBase(ShopContext context)
        {
            this.context = context;
            this.myEntity = context.Set<TEntity>();
            
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.myEntity.Any(filter);
        }

        public virtual List<TEntity> GetEntities()
        {
            return this.myEntity.ToList();
        }

        public virtual TEntity GetEntity(int id)
        {
            return this.myEntity.Find(id); 
        }

        public virtual void Remove(TEntity entity)
        {
             this.myEntity.Remove(entity);
        }

        public virtual void Remove(TEntity[] entities)
        {
            this.myEntity.RemoveRange(entities);
        }

        public virtual void Save(TEntity entity)
        {
            this.myEntity.Add(entity);
        }

        public virtual void Save(TEntity[] entities)
        {
            this.myEntity.AddRange(entities);
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            this.context.Update(entity);
        }

        public virtual void Update(TEntity[] entities)
        {
            this.context.UpdateRange(entities);
        }
    }
}
