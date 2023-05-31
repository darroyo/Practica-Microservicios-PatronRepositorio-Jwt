using PatronRepositorio.Dtos;
using PatronRepositorio.Repository.Common;
using System.Linq.Expressions;

namespace PatronRepositorio.Services
{
    public class FinancialService : IFinancialService
    {
        private IUnitOfWork _UnitOfWorkRepository;
        public FinancialService(IUnitOfWork UnitOfWorkRepository)
        {
            _UnitOfWorkRepository = UnitOfWorkRepository;
        }

        public async Task<FinancialDataDto> GetAllEconomicalDataAsync()
        {
            var hamburguesas = 
                await _UnitOfWorkRepository.HamburguesaRepository
                .GetAll(includeProperties:"Comida");

            var alitas = await _UnitOfWorkRepository.AlitaRepository
                .GetAll(includeProperties: "Comida");

            var comida = hamburguesas.Select(x => x.Comida).Union(
                alitas.Select(x => x.Comida)
            );

            return new FinancialDataDto
            {
                SumOfCoste = comida.Select(x => x.Coste).DefaultIfEmpty(0).Sum(),
                SumOfVenta = comida.Select(x => x.Venta.GetValueOrDefault(0)).DefaultIfEmpty(0).Sum(),
                SumOfNumbers = comida.Select(x => x.Coste).DefaultIfEmpty(0).Count(),
                SumOfDiference = comida.Select(x => x.Venta.GetValueOrDefault(0)).DefaultIfEmpty(0).Sum() - comida.Select(x => x.Coste).DefaultIfEmpty(0).Sum()
            };
        }
    }
}
