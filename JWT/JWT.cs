using System.Security.Claims;

namespace JWT
{
    public class JWT
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

        public static Usuario? dameUsuarioPorToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity == null || identity.Claims.Count()==0)
                {
                    return null;
                }

                var Id = identity.Claims.FirstOrDefault(x => x.Type == "IdUsuario").Value;// todo, esto no creo que sea muy seguro
                var usuario = Usuario.DB().FirstOrDefault(x => x.Id.ToString() == Id);
                
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
