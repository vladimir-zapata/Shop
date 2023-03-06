using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Shop.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Shop.DAL.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ShopContext context;
        private DbSet<TEntity> entities;
        public RepositoryBase(ShopContext context)
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }
        public virtual bool Exists(Expression<Func<TEntity, bool>> filter)
        {
           return this.entities.Any(filter);
        }
        public virtual List<TEntity> GetEntities()
        {
           return this.entities.ToList();
        }
        public virtual TEntity GetEntity(int id)
        {
            return this.entities.Find(id);
        }
        public virtual void Remove(TEntity entity)
        {
           this.entities.Remove(entity);
        }
        public virtual void Remove(TEntity[] entities)
        {
            this.entities.RemoveRange(entities);
        }
        public virtual void Save(TEntity entity)
        {
           this.entities.Add(entity);
        }
        public virtual void Save(TEntity[] entities)
        {
           this.entities.AddRange(entities);
        }
        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }
        public virtual void Update(TEntity entity)
        {
           this.entities.Update(entity);
        }
        public virtual void Update(TEntity[] entities)
        {
           this.entities.UpdateRange(entities);    
        }
    }
}
