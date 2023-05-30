using ApiRestful.Models;
using ApiRestful.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestful.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SandwichController : ControllerBase
    {
        private ILogger<SandwichController> _logger;

        public SandwichController(ILogger<SandwichController> logger)
        {
            this._logger = logger;
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Sandwich>> GetAll() {
            _logger.LogInformation("GetAll called LogInformation");
            _logger.LogWarning("GetAll called LogWarning");
            _logger.LogError("GetAll called LogError");
            _logger.LogCritical("GetAll called LogCritical");
            return SandwichService.GetAll();
        }

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Sandwich> Get(int id)
        {
            var Sandwich = SandwichService.Get(id);

            if (Sandwich == null)
                return NotFound();

            return Sandwich;
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Sandwich Sandwich)
        {
            SandwichService.Add(Sandwich);
            return CreatedAtAction(nameof(Get), new { id = Sandwich.Id }, Sandwich);
        }

        // PUT action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Sandwich Sandwich)
        {
            if (id != Sandwich.Id)
                return BadRequest();

            var existingSandwich = SandwichService.Get(id);
            if (existingSandwich is null)
                return NotFound();

            SandwichService.Update(Sandwich);

            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Sandwich = SandwichService.Get(id);

            if (Sandwich is null)
                return NotFound();

            SandwichService.Delete(id);

            return NoContent();
        }
    }
}
