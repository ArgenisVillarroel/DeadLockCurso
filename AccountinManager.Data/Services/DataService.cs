using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AccountinManager.Data.Services
{
    public abstract class DataService<TEntity, TContext>
        where TEntity: class
        where TContext: DbContext
    {
        private TContext context;
        private DbSet<TEntity> table;

        public DataService(TContext context)
        {
            this.context = context;
            table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter, string[] includeColumns)
        {
            IQueryable<TEntity> result = table;
            foreach (string includeColumn in includeColumns)
            {
               result = result.Include(includeColumn);
            }
            return result.Where(filter);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            IQueryable<TEntity> result = table;
            return result.Where(filter);
        }

        public IQueryable<TEntity> GetAll(string[] includeColumns)
        {
            IQueryable<TEntity> result = table;
            foreach (string includeColumn in includeColumns)
            {
                result = result.Include(includeColumn);
            }
            return result;
        }



    }
}
