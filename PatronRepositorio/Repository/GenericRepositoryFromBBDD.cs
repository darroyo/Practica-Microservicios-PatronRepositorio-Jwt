using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;
using AutoMapper;

namespace PatronRepositorio.Repository
{

    public class GenericRepositoryFromBBDD<X, Y> : IGenericRepository<X, Y> where X : class where Y : class
    {
        internal MyDbContext context;
        internal DbSet<X> dbSet;
        internal IMapper mapper;

        public GenericRepositoryFromBBDD(MyDbContext context, IMapper mapper)
        {
            this.context = context;
            this.dbSet = context.Set<X>();
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Y>> Get(
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
                return mapper.Map<IEnumerable<Y>>(await orderBy(query).ToListAsync());
            }
            else
            {
                return mapper.Map<IEnumerable<Y>>(await query.ToListAsync());
            }
        }

        public async Task<Y> GetByID(object id)
        {
            return mapper.Map<Y>(await dbSet.FindAsync(id));
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
