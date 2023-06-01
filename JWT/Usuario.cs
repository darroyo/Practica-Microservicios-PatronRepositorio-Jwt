namespace JWT
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public string password { get; set; }

        public static List<Usuario> DB (){
            return new List<Usuario>{
                new Usuario
                {
                    Id = 1,
                    Nombre = "Puede",
                    Rol = "Administrador",
                    password = "123"
                },
                new Usuario
                {
                    Id = 2,
                    Nombre = "NO Puede",
                    Rol = "Empleado",
                    password = "123"
                },
                new Usuario
                {
                    Id = 3,
                    Nombre = "NO Puede",
                    Rol = "Empleado",
                    password = "123"
                }
            };
        }
    }
}
