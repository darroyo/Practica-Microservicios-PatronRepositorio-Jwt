using PatronRepositorio.Data;

namespace PatronRepositorio.Repository
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(MyDbContext context_) { 
            this.context = context_;
        }
        private MyDbContext context;
        private IGenericRepository<Pizza> _PizzaRepository;

        public IGenericRepository<Pizza> PizzaRepository
        {
            get
            {

                if (this._PizzaRepository == null)
                {
                    this._PizzaRepository = new GenericRepositoryFromBBDD<Pizza>(context);
                }
                // SI QUISIERAMOS QUE PIZZA TIRARA DE OTRO REPO, SOLO TENDRIAMOS QUE TOCAR AQUI
                // this._PizzaRepository = new GenericRepositoryFromFile<Pizza>("Mi fichero");
                return _PizzaRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
