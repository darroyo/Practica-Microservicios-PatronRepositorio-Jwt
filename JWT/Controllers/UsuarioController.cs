using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuarioController:ControllerBase
    {
        IConfiguration _config;
        public UsuarioController(IConfiguration config) { 
            _config = config;
        }

        [HttpPost(Name = "IniciarSesion")]
        public dynamic IniciarSesion([FromBody] object optData)
        {
            var data =
                JsonConvert.DeserializeObject<dynamic>
                (optData.ToString());

            string nombre = data.Nombre.ToString();
            string password = data.Password.ToString();

            Usuario usuario =
                Usuario
                .DB()
                .FirstOrDefault(x => x.password == password
                && x.Nombre == nombre);

            // ko
            if(usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas"
                };
            }

            // ok
            var jwt = (JWT)_config.GetSection("Jwt").Get<JWT>();

            // todo lo que se almacena en nuestro token
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                
                // A partir de aqui lo que queramos
                new Claim("IdUsuario", usuario.Id.ToString()),
                new Claim("Nombre", usuario.Nombre),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.Key)
            );
            var signIn = new SigningCredentials(
                key, 
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddDays(1), // Opcional
                signingCredentials: signIn
            );

            return new
            {
                success = true,
                message = "Credenciales correctas",
                result= new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
