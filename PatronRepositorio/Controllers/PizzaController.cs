using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;
using PatronRepositorio.Repository;

namespace PatronRepositorio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {

        private readonly ILogger<PizzaController> _logger;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;

        public PizzaController(ILogger<PizzaController> logger, UnitOfWork UnitOfWork,
            IMapper mapper)
        {
            _logger = logger;
            _UnitOfWork = UnitOfWork;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<PizzaDto>> Get()
        {
            var xx = await _UnitOfWork.PizzaRepository.Get();
            return _mapper.Map<IEnumerable<PizzaDto>>(xx);
        }
    }
}