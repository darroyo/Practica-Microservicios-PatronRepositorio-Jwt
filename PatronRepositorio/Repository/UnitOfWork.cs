using AutoMapper;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;

namespace PatronRepositorio.Repository
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(MyDbContext context_, IMapper mapper_) { 
            this.context = context_;
            this.mapper = mapper_;
        }
        private MyDbContext context;
        private IMapper mapper;
        private IGenericRepository<Pizza,PizzaDto> _PizzaRepository;

        public IGenericRepository<Pizza, PizzaDto> PizzaRepository
        {
            get
            {

                if (this._PizzaRepository == null)
                {
                    this._PizzaRepository = 
                        new GenericRepositoryFromBBDD<Pizza, PizzaDto>(context, mapper);
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
