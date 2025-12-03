namespace TiendaApp.Modelo.Entities
{
    public class VentaDetalle
    {
        public int Id { get; set; }

        public int VentaId { get; set; }
        public Venta Venta { get; set; } = null!;

        public int ArticuloId { get; set; }
        public Articulo Articulo { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}