using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        // todo, puede ser a nivel de método o de controlador
        // en este caso solo usuarios logueados, SOLO LOS USUARIOS LOGEADOS TENDRÁN UN TOKEN CORRECTO
        // LO QUE HACE ESTO ES VERIFICAR QUE SE PASA UN TOKEN CORRECTO CON LA CONFIGURACIÓN QUE HEMOS
        // PUESTO EN EL PROGRAM, ES DECIR, CLAVE CORRECTA, NO EXPIRADA... ETC -->
        // builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        [Authorize]
        [HttpGet(Name = "GetWeatherForecastOnlyLogged")]
        public IEnumerable<WeatherForecast> GetWeatherForecastOnlyLogged()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet(Name = "GetWeatherForecastOnlyLoggedAndAdminsVersionMejorada")]
        public dynamic GetWeatherForecastOnlyLoggedAndAdminsVersionMejorada()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [Authorize]
        [HttpGet(Name = "GetWeatherForecastOnlyLoggedAndAdminsVersionCutre")]
        public dynamic GetWeatherForecastOnlyLoggedAndAdminsVersionCutre()
        {
            // todo
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var usuario = JWT.dameUsuarioPorToken(identity);

            if(usuario == null || usuario.Rol !="Administrador")
            {
                return null;
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