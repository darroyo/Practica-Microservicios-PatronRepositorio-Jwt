namespace PatronRepositorio.Data
{
    public class Comida
    {
        private double? venta;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Coste { get; set; }
        // todo, esto es un poco ñapa, pero al tener un repo genérico, no podemos personalizar
        // comida y, aunque pudiéramos, tendríamos que cambiarlo en n sitios

        // aún asi tendríamos que personalizarlo con una clase abstracta que herede de la interfaz
        // y hacer un override de los métodos que devuelven datos

        // https://www.geeksforgeeks.org/c-sharp-abstract-classes/
        public double? Venta { get => (venta==null?5000:venta); set => venta = value; }
        public virtual List<Alita> Alitas { get; set; }
        public virtual List<Hamburguesa> Hamburguesas { get; set; }
    }
}
