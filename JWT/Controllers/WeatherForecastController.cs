using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JWT.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecastAll")]
        public IEnumerable<WeatherForecast> GetWeatherForecastAll()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [Authorize] // Mejor asi, verifica antes de entrar al código que el token es correcto,
        // todo, pero, como lo hace???
        [HttpGet(Name = "GetWeatherForecastOnlyAdmins")]
        public dynamic GetWeatherForecastOnlyAdmins()
        {
            // todo
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var rToken = JWT.validarToken(identity);

            if (!rToken.success)
            {
                return rToken;
            }

            Usuario usuario = rToken.result;

            if(usuario.Rol != "Administrador")
            {
                return new
                {
                    success = false,
                    message = "No tienes permiso para acceder a esto ni a esta app"
                };
            }

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}