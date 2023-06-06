using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace Excepciones.Middlewares
{
    public class GlobalExceptionHandlingMiddleware:IMiddleware
    {
        // todo middleware para gestionar errores
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(
            ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(
            HttpContext context, 
            RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                // Guardamos error, todo, logger servicio externo, como se haría???
                _logger.LogError(ex, ex.Message);

                // Modificamos response para devovler
                context.Response.StatusCode = 
                    (int)HttpStatusCode.InternalServerError;

                // Customizamos respuesta
                ProblemDetails problem = new ProblemDetails()
                {
                    Status = (int)HttpStatusCode.InternalServerError,
                    Type = "Server Error",
                    Title = "Server Error Title",
                    Detail = "Internal server error has ocurred"
                };
                
                var json = JsonSerializer.Serialize(problem);
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
