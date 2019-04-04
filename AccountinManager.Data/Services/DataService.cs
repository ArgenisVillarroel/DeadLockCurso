using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<TEntity> GetAll()
        {
            return table;
        }


    }
}
