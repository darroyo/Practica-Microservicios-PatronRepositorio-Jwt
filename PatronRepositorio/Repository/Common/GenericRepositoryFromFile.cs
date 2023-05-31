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

    public class GenericRepositoryFromFile<X> : IGenericRepository<X> where X : class
    {
        private string FilePath { get; set; }

        public GenericRepositoryFromFile(string FilePath)
        {
            this.FilePath = FilePath;
        }

        public Task<IEnumerable<X>> GetAll(Expression<Func<X, bool>> filter = null, Func<IQueryable<X>, IOrderedQueryable<X>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public Task<X> GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public Task Insert(X entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(object id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(X entityToDelete)
        {
            throw new NotImplementedException();
        }

        public Task Update(X entityToUpdate)
        {
            throw new NotImplementedException();
        }
    }

}
