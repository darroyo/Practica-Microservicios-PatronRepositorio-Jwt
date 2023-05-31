using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatronRepositorio.Repository.Common
{
    public interface IGenericRepository<X> where X : class
    {

        Task<IEnumerable<X>> GetAll(
            Expression<Func<X, bool>> filter = null,
            Func<IQueryable<X>, IOrderedQueryable<X>> orderBy = null,
            string includeProperties = "");

        public Task<X> GetByID(object id);

        Task Insert(X entity);

        Task Delete(object id);

        Task Delete(X entityToDelete);

        Task Update(X entityToUpdate);
    }
}
