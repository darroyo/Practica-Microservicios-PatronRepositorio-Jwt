using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PatronRepositorio.Data
{
    public class Alita
    {
        [Key]
        public int Id { get; set; }
        public string NombreDelPollo { get; set; }
        public bool EsMuslito { get; set; }
        public virtual Comida Comida { get; set; }
    }
}
