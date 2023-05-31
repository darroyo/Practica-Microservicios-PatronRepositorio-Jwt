using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;
using PatronRepositorio.Repository;
using PatronRepositorio.Repository.Common;
using PatronRepositorio.Services;

namespace PatronRepositorio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FinancialController : ControllerBase
    {

        private readonly ILogger<FinancialController> _logger;
        private readonly IFinancialService _FinancialService;

        public FinancialController(ILogger<FinancialController> logger, IFinancialService FinancialService,
            IMapper mapper)
        {
            _logger = logger;
            _FinancialService = FinancialService;
        }


        [HttpGet(Name = "GetAllEconomicalDataAsync")]
        public async Task<FinancialDataDto> GetAllEconomicalDataAsync()
        {
            return await _FinancialService.GetAllEconomicalDataAsync();
        }
    }
}