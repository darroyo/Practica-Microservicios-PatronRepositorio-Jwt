using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;

namespace PatronRepositorio.Repository
{

    public class GenericRepositoryFromFile<T>:IGenericRepository<T> where T : class
    {

        public GenericRepositoryFromFile(string filePAth)
        {
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
