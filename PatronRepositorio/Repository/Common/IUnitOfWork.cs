using PatronRepositorio.Data;

namespace PatronRepositorio.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Comida> ComidaRepository { get; }
        public IGenericRepository<Hamburguesa> HamburguesaRepository { get;  }
        public IGenericRepository<Alita> AlitaRepository { get;  }
    }
}
