using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Shop.DAL.Context;
using Shop.DAL.Exceptions;
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
            try
            {
                return this.myEntity.Any(filter);
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error al obtener el producto");
            }
        }

        public virtual List<TEntity> GetEntities()
        {
            try
            {
                return this.myEntity.ToList();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error listando los productos");
            }

        }

        public virtual TEntity GetEntity(int id)
        {
            try
            {
                return this.myEntity.Find(id);
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error encontrando el producto");
            }
        }

        public virtual void Remove(TEntity entity)
        {
            try
            {
                this.myEntity.Remove(entity);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error removiendo el producto");
            }
        }

        public virtual void Remove(TEntity[] entities)
        {
            try
            {
                this.myEntity.RemoveRange(entities);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un error removiendo los productos");
            }
        }

        public virtual void Save(TEntity entity)
        {
            try
            {
                this.myEntity.Add(entity);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un guardando el producto");
            }
        }

        public virtual void Save(TEntity[] entities)
        {
            try
            {
                this.myEntity.AddRange(entities);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un guardando los productos");
            }
        }

        public virtual void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                this.context.Update(entity);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un actualizando el producto");
            }
        }

        public virtual void Update(TEntity[] entities)
        {
            try
            {
                this.context.UpdateRange(entities);
                this.context.SaveChanges();
            }
            catch (ProductDataException)
            {
                throw new ProductDataException("Ha ocurrido un actualizando los productos");
            }
        }
    }
}
