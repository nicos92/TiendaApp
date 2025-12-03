using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Servicio.Dominio
{
    public class VentaDetalleServicio(IVentaDetalleRepositorio ventaDetalleRepositorio) : IVentaDetalleServicio
    {
        public async Task<IEnumerable<VentaDetalle>> GetAllAsync()
        {
            return await ventaDetalleRepositorio.GetAllAsync();
        }

        public async Task<VentaDetalle?> GetByIdAsync(int id)
        {
            return await ventaDetalleRepositorio.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VentaDetalle>> GetByVentaIdAsync(int ventaId)
        {
            return await ventaDetalleRepositorio.GetByVentaIdAsync(ventaId);
        }

        public async Task<IEnumerable<VentaDetalle>> GetByArticuloIdAsync(int articuloId)
        {
            return await ventaDetalleRepositorio.GetByArticuloIdAsync(articuloId);
        }

        public async Task<int> CreateAsync(VentaDetalle ventaDetalle)
        {
            return await ventaDetalleRepositorio.CreateAsync(ventaDetalle);
        }

        public async Task<bool> UpdateAsync(VentaDetalle ventaDetalle)
        {
            return await ventaDetalleRepositorio.UpdateAsync(ventaDetalle);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await ventaDetalleRepositorio.DeleteAsync(id);
        }
    }
}
