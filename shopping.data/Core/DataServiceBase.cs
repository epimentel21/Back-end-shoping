using Microsoft.EntityFrameworkCore;
using shopping.data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopping.data.Core
{
    public class DataServiceBase<TId,TEntity, TContext>
        where TEntity: ModelBase<TId>
        where TContext : DbContext
        where TId: IEquatable<TId>
    {
        protected TContext context;

        public DataServiceBase(TContext context)
        {
            this.context = context;
        }

        public TId AddOrUpdate(TEntity entity)
        {
            if (entity.IsNewModel())
            {
                context.Add(entity);
            }
            else
            {
                var originalEntity = context.Find<TEntity>(entity.Id);
                
            }

           context.SaveChanges();

            return entity.Id;
        }

        public IQueryable<TEntity> GetAll()
        {
            DbSet<TEntity> table = context.Set<TEntity>();
            return table;
        }

        public TEntity GetItemById(TId Id)
        {
            DbSet<TEntity> table = context.Set<TEntity>();
            TEntity entity = table.Find(Id);
            return entity;
        }

        public TEntity GetItemByIdD(TId Id)
        {
            DbSet<TEntity> table = context.Set<TEntity>();
            TEntity entity = table.Find(Id);
            return entity;
        }

        public int DeleteItemById(TId Id)
        {
            TEntity entity = context.Find<TEntity>(Id);
            context.Remove(entity);
            return context.SaveChanges();
        }
    }
}
