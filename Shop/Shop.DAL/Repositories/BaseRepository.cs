using Microsoft.EntityFrameworkCore;
using Shop.Core.Abstractions.Repositories;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DAL.Repositories
{
    public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        protected readonly ShopContext context;

        public BaseRepository(ShopContext context)
        {
            this.context = context;
        }

        public TEntity GetById(TId id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void AddMany(IEnumerable<TEntity> entities)
        {
            context.AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void DeleteById(TId id)
        {
            TEntity found = context.Set<TEntity>().Find(id);
            if (found != null)
                context.Set<TEntity>().Remove(found);
            else
                throw new ArgumentException($"Couldn't find an entity with id {id}.");
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            context.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public int Count()
        {
            return context.Set<TEntity>().Count();
        }
    }
}
