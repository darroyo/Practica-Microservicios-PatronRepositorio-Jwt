using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;
using PatronRepositorio.Repository;

namespace PatronRepositorio.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //public class PizzaController : ControllerBase
    //{

    //    private readonly ILogger<PizzaController> _logger;
    //    private readonly UnitOfWorkService _UnitOfWorkService;

    //    public PizzaController(ILogger<PizzaController> logger, UnitOfWorkService UnitOfWork,
    //        IMapper mapper)
    //    {
    //        _logger = logger;
    //        _UnitOfWorkService = UnitOfWork;
    //    }

    //    [HttpGet(Name = "Get")]
    //    public async Task<IEnumerable<object>> Get()
    //    {
    //        return await _UnitOfWorkService.FoodService.GetAllById(0);
    //    }
    //    [HttpGet("{filter}", Name = "GetWithFilter")]
    //    public async Task<IEnumerable<object>> GetWithFilter(int filter)
    //    {
    //        return await _UnitOfWorkService.FoodService.GetAllById(filter);
    //    }
    //}
}