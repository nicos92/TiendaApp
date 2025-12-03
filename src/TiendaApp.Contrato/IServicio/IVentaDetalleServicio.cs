using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IServicio
{
    public interface IVentaDetalleServicio
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