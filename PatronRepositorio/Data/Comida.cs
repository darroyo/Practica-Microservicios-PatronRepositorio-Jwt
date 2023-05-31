namespace PatronRepositorio.Data
{
    public class Comida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Coste { get; set; }
        public double? Venta { get; set; }
        public virtual List<Alita> Alitas { get; set; }
        public virtual List<Hamburguesa> Hamburguesas { get; set; }
    }
}
