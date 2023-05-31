using AutoMapper;
using PatronRepositorio.Dtos;
using PatronRepositorio.Repository.Common;
using System.Linq;

namespace PatronRepositorio.Services
{
    public class FoodService:IFoodService
    {
        private IUnitOfWork _UnitOfWorkRepository;
        private IMapper _mapper;
        public FoodService(IUnitOfWork UnitOfWorkRepository,
            IMapper mapper) { 
            _UnitOfWorkRepository = UnitOfWorkRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComidaDto>> GetAlitas()
        {
            return
                _mapper.Map<IEnumerable<ComidaDto>>(
                    await _UnitOfWorkRepository.AlitaRepository.GetAll(includeProperties:"Comida")
                );
        }

        public async Task<IEnumerable<ComidaDto>> GetHamburguesas()
        {
            return
                _mapper.Map<IEnumerable<ComidaDto>>(
                    await _UnitOfWorkRepository.HamburguesaRepository.GetAll(includeProperties: "Comida")
                );
        }

        public async Task<IEnumerable<ComidaDto>> GetAll()
        {
            return
                _mapper.Map<IEnumerable<ComidaDto>>(
                    (await GetAlitas())
                    .Union(
                        (await GetHamburguesas())
                     )
                ); ;
        }
    }
}
