using PatronRepositorio.Dtos;
using PatronRepositorio.Repository.Common;
using System.Linq.Expressions;

namespace PatronRepositorio.Services
{
    public interface IFinancialService
    {
        public Task<FinancialDataDto> GetAllEconomicalDataAsync();
    }
}
