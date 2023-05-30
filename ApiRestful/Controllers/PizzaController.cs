using ApiRestful.Models;
using ApiRestful.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private ILogger<PizzaController> _logger;

        public PizzaController(ILogger<PizzaController> logger)
        {
            this._logger = logger;
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() {
            _logger.LogInformation("GetAll called LogInformation");
            _logger.LogWarning("GetAll called LogWarning");
            _logger.LogError("GetAll called LogError");
            _logger.LogCritical("GetAll called LogCritical");
            return PizzaService.GetAll();
        }

        /// <summary>
        /// Retorna un objeto pizza
        /// </summary>
        /// <param name="id">ID de la pizza a consultar</param>
        /// <returns>Return Pizza</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /api/priceframe/5/10
        ///
        /// </remarks>
        /// <response code="200">Returns the cost of the frame in dollars.</response>
        /// <response code="400">If the amount of frame material needed is less than 20 inches or greater than 1000 inches.</response>
        [HttpGet("{id}", Name = nameof(Get))]
        [Produces("text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
