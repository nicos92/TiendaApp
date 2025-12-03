using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Servicio.Dominio
{
    public class VentaServicio(IVentaRepositorio ventaRepositorio, IVentaDetalleRepositorio ventaDetalleRepositorio) : IVentaServicio
    {
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            return await ventaRepositorio.GetAllAsync();
        }

        public async Task<Venta?> GetByIdAsync(int id)
        {
            return await ventaRepositorio.GetByIdAsync(id);
        }

        public async Task<int> CreateAsync(Venta venta)
        {
            return await ventaRepositorio.CreateAsync(venta);
        }

        public async Task<bool> UpdateAsync(Venta venta)
        {
            return await ventaRepositorio.UpdateAsync(venta);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await ventaRepositorio.DeleteAsync(id);
        }

        public async Task<IEnumerable<VentaDetalle>> GetVentaDetalleAsync(int ventaId)
        {
            return await ventaDetalleRepositorio.GetByVentaIdAsync(ventaId);
        }
    }
}
