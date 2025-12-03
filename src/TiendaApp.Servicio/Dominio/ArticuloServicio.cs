using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Servicio.Dominio
{
    public class ArticuloServicio(IArticuloRepositorio articuloRepositorio) : IArticuloServicio
    {
        public async Task<IEnumerable<Articulo>> GetAllAsync()
        {
            return await articuloRepositorio.GetAllAsync();
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await articuloRepositorio.GetByIdAsync(id);
        }

        public async Task<Articulo?> GetByNameAsync(string nombre)
        {
            return await articuloRepositorio.GetByNameAsync(nombre);
        }

        public async Task<int> CreateAsync(Articulo articulo)
        {
            return await articuloRepositorio.CreateAsync(articulo);
        }

        public async Task<bool> UpdateAsync(Articulo articulo)
        {
            return await articuloRepositorio.UpdateAsync(articulo);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await articuloRepositorio.DeleteAsync(id);
        }
    }
}
