using PatronRepositorio.Data;

namespace PatronRepositorio.Repository.Common
{
    public class UnitOfWorkFromFile : IUnitOfWork
    {
        public IGenericRepository<Comida> ComidaRepository => throw new NotImplementedException();

        public IGenericRepository<Hamburguesa> HamburguesaRepository => throw new NotImplementedException();

        public IGenericRepository<Alita> AlitaRepository => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
