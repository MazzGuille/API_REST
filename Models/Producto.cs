using System.ComponentModel.DataAnnotations;

namespace API_REST.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Required]
        public string? Nombre { get; set; } //= "Objeto no existe";
        [Required]
        public string? Descripcion { get; set; }


    }
}
