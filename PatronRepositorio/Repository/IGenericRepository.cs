using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatronRepositorio.Repository
{
    public interface IGenericRepository<X,Y> where X : class where Y : class
    {

        Task<IEnumerable<Y>> Get(
            Expression<Func<X, bool>> filter = null,
            Func<IQueryable<X>, IOrderedQueryable<X>> orderBy = null,
            string includeProperties = "");

        public Task<Y> GetByID(object id);

        Task Insert(X entity);

        Task Delete(object id);

        Task Delete(X entityToDelete);

        Task Update(X entityToUpdate);
    }
}
