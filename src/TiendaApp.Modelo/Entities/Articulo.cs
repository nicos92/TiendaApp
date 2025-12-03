using System.ComponentModel.DataAnnotations;

namespace TiendaApp.Modelo.Entities
{
    public class Articulo
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        
        public decimal Precio { get; set; }
        
        public int Stock { get; set; } = 0;
        
        public ICollection<VentaDetalle> VentasDetalle { get; set; } = [];
    }
}
