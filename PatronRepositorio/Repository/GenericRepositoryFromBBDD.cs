using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;

namespace PatronRepositorio.Repository
{

    public class GenericRepositoryFromBBDD<T>:IGenericRepository<T> where T : class
    {
        internal MyDbContext context;
        internal DbSet<T> dbSet;

        public GenericRepositoryFromBBDD(MyDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Delete(object id)
        {
            T entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);
        }

        public async Task Delete(T entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task Update(T entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

}
