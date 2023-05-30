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

        public PizzaController(ILogger<PizzaController> logger, UnitOfWork UnitOfWork,
            IMapper mapper)
        {
            _logger = logger;
            _UnitOfWork = UnitOfWork;
        }

        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<PizzaDto>> Get()
        {
            return await _UnitOfWork.PizzaRepository.Get();
        }
        [HttpGet("{filter}", Name = "GetWithFilter")]
        public async Task<IEnumerable<PizzaDto>> GetWithFilter(int filter)
        {
            return await _UnitOfWork.PizzaRepository.Get(x=>x.Id > filter);
        }

        [HttpPost(Name = "Insert")]
        public async Task Set(Pizza pizza)
        {
            await _UnitOfWork.PizzaRepository.Insert(pizza);
            _UnitOfWork.Save();// todo, no se si es correcto ponerlo aqui
        }
    }
}