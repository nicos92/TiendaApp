using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IServicio
{
    public interface IVentaServicio
    {
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task<int> CreateAsync(Venta venta);
        Task<bool> UpdateAsync(Venta venta);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<VentaDetalle>> GetVentaDetalleAsync(int ventaId);
    }
}