using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatronRepositorio.Repository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        public Task<T> GetByID(object id);

        Task Insert(T entity);

        Task Delete(object id);

        Task Delete(T entityToDelete);

        Task Update(T entityToUpdate);
    }
}
