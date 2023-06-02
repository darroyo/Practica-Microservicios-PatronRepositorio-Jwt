using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public dynamic IniciarSesion(UsuarioLogin UsuarioLogin)
        {

            Usuario usuario =
                Usuario
                .DB()
                .FirstOrDefault(x => x.password == UsuarioLogin.password
                && x.Nombre == UsuarioLogin.Nombre);

            // ko
            if (usuario == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas"
                };
            }

            // ok
            return new
            {
                success = true,
                message = "Credenciales correctas",
                result = GenerateToken(usuario)
            };
        }

        private string GenerateToken(Usuario usuario)
        {            
            var jwt = (JWT)_config.GetSection("Jwt").Get<JWT>();

            // todo lo que se almacena en nuestro token
            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Jti, new Guid().ToString()),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role, usuario.Rol),// IMPORTANTISIMO USAR ESTE PARA LUEGO PODER USAR COMODAMENTE [Authorize(Roles = "Administrador")] EN METODO O CONTROLADOR
                
                // A partir de aqui los valores personalizados que queramos
                // CUIDADO QUE ESTA INFO ES PÚBLICA, NO SE ENCRIPTA
                new Claim("IdUsuario", usuario.Id.ToString()),
                new Claim("Nombre", usuario.Nombre),
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt.Key)
            );
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddDays(1), // Opcional
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
