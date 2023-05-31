using System.ComponentModel.DataAnnotations;

namespace PatronRepositorio.Data
{
    public class Hamburguesa
    {
        [Key]
        public int Id { get; set; }
        public int NumeroCarnes { get; set; }
        public bool LlevaPepino { get; set; }
        public virtual Comida Comida { get; set; }
    }
}
