using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IVentaDetalleRepositorio
    {
        Task<IEnumerable<VentaDetalle>> GetAllAsync();
        Task<VentaDetalle?> GetByIdAsync(int id);
        Task<IEnumerable<VentaDetalle>> GetByVentaIdAsync(int ventaId);
        Task<IEnumerable<VentaDetalle>> GetByArticuloIdAsync(int articuloId);
        Task<int> CreateAsync(VentaDetalle ventaDetalle);
        Task<bool> UpdateAsync(VentaDetalle ventaDetalle);
        Task<bool> DeleteAsync(int id);
    }
}
