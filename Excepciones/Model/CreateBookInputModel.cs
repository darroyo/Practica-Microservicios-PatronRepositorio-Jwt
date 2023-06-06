using System.ComponentModel.DataAnnotations;

namespace ExcepcionesGlobales.Model
{
    public class CreateBookInputModel
    {
        [Required]
        public string? Title { get; set; }
        [MaxLength(250)]
        public string? Description { get; set; }
        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string? ISBN { get; set; }
    }
}
