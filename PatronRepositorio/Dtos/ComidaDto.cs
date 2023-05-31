using Microsoft.EntityFrameworkCore;
using PatronRepositorio.Data;
using System.ComponentModel.DataAnnotations;

namespace PatronRepositorio.Dtos
{
    public class ComidaDto
    {
        public string Nombre { get; set; }
        public double? Venta { get; set; }
        public ComidaType Type { get; set; }
        public object MoreInfo { get; set; }
    }

    public enum ComidaType
    {
        Hamburguesa,
        Alita
    }
}
