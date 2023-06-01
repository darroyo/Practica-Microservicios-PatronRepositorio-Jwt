using System.Security.Claims;

namespace JWT
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }
    
        public static dynamic validarToken(ClaimsIdentity identity)
        {
            try
            {
                if(identity.Claims.Count()==0)
                {

                    return new
                    {
                        success = false,
                        message = "Token no valido"
                    };
                }

                // Necesitamos saber el usuario al que
                // pertenece el token
                var Id = identity.Claims.FirstOrDefault(x=>x.Type == "IdUsuario").Value;

                var usuario = Usuario.DB().FirstOrDefault(x => x.Id.ToString() == Id);

                if(usuario == null)
                {
                    return new
                    {
                        success = false,
                        message = "Usuario no encontrado"
                    };
                }

                return new
                {
                    success = true,
                    message = "Token valido",
                    result = usuario
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    message = ex.Message
                };
            }
        }
    }
}
