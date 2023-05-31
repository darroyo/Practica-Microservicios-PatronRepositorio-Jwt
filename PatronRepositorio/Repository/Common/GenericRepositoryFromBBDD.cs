using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;
using AutoMapper;

namespace PatronRepositorio.Repository.Common
{

    public class GenericRepositoryFromBBDD<X> : IGenericRepository<X> where X : class
    {
        internal MyDbContext context;
        internal DbSet<X> dbSet;

        public GenericRepositoryFromBBDD(MyDbContext context)
        {
            this.context = context;
            dbSet = context.Set<X>();
        }

        public async Task<IEnumerable<X>> GetAll(
            Expression<Func<X, bool>> filter = null,
            Func<IQueryable<X>, IOrderedQueryable<X>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<X> query = dbSet;

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

        public async Task<X> GetByID(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task Insert(X entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task Delete(object id)
        {
            X entityToDelete = dbSet.Find(id);
            await Delete(entityToDelete);
        }

        public async Task Delete(X entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async Task Update(X entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }

}
