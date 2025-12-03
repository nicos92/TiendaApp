using System.ComponentModel.DataAnnotations;

namespace TiendaApp.Modelo.Entities
{
    public class Venta
    {
        public int Id { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        
        public ICollection<VentaDetalle> VentasDetalle { get; set; } = [];
    }
}
