using PatronRepositorio.Data;

namespace PatronRepositorio.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Hamburguesa> HamburguesaRepository { get;  }
        public IGenericRepository<Alita> AlitaRepository { get;  }
    }
}
