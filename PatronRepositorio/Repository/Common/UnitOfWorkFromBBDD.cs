using PatronRepositorio.Data;

namespace PatronRepositorio.Repository.Common
{
    public class UnitOfWorkFromBBDD : IUnitOfWork
    {
        public UnitOfWorkFromBBDD(MyDbContext context_)
        {
            context = context_;
        }
        private MyDbContext context;
        private IGenericRepository<Comida> _ComidaRepository;
        private IGenericRepository<Hamburguesa> _HamburguesaRepository;
        private IGenericRepository<Alita> _AlitaRepository;

        public IGenericRepository<Comida> ComidaRepository
        {
            get
            {

                if (_ComidaRepository == null)
                {
                    _ComidaRepository =
                        new GenericRepositoryFromBBDD<Comida>(context);
                }
                return _ComidaRepository;
            }
        }

        public IGenericRepository<Hamburguesa> HamburguesaRepository
        {
            get
            {

                if (_HamburguesaRepository == null)
                {
                    _HamburguesaRepository =
                        new GenericRepositoryFromBBDD<Hamburguesa>(context);
                }
                return _HamburguesaRepository;
            }
        }

        public IGenericRepository<Alita> AlitaRepository
        {
            get
            {

                if (_AlitaRepository == null)
                {
                    _AlitaRepository =
                        new GenericRepositoryFromBBDD<Alita>(context);
                }
                return _AlitaRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
