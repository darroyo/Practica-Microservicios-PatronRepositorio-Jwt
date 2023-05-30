using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;

namespace PatronRepositorio.Repository
{

    public class GenericRepositoryFromFile<X,Y>:IGenericRepository<X, Y> where X : class where Y : class
    {

        public GenericRepositoryFromFile(string filePAth)
        {
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(X entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Y>> Get(Expression<Func<X, bool>> filter = null, Func<IQueryable<X>, IOrderedQueryable<X>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<Y> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(X entity)
        {
            throw new NotImplementedException();
        }

        public Task Update(X entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
