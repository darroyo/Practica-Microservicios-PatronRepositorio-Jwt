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
    public class FoodController : ControllerBase
    {

        private readonly ILogger<FoodController> _logger;
        private readonly IFoodService _FoodService;

        public FoodController(ILogger<FoodController> logger, IFoodService FoodService,
            IMapper mapper)
        {
            _logger = logger;
            _FoodService = FoodService;
        }


        [HttpGet(Name = "GetAlitas")]
        public async Task<IEnumerable<ComidaDto>> GetAlitas()
        {
            return await _FoodService.GetAlitas();
        }

        [HttpGet(Name = "GetHamburguesas")]
        public async Task<IEnumerable<ComidaDto>> GetHamburguesas()
        {
            return await _FoodService.GetHamburguesas();
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IEnumerable<ComidaDto>> GetAll()
        {
            return await _FoodService.GetAll();
        }
    }
}