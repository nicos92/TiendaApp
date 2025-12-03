using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IVentaRepositorio
    {
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<Venta?> GetByIdAsync(int id);
        Task<int> CreateAsync(Venta venta);
        Task<bool> UpdateAsync(Venta venta);
        Task<bool> DeleteAsync(int id);
    }
}
