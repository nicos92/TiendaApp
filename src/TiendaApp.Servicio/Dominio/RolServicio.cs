using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Servicio.Dominio
{
    public class RolServicio(IRolRepositorio rolRepositorio) : IRolServicio
    {
        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await rolRepositorio.GetAllAsync();
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            return await rolRepositorio.GetByIdAsync(id);
        }

        public async Task<Rol?> GetByNameAsync(string nombre)
        {
            return await rolRepositorio.GetByNameAsync(nombre);
        }

        public async Task<int> CreateAsync(Rol rol)
        {
            return await rolRepositorio.CreateAsync(rol);
        }

        public async Task<bool> UpdateAsync(Rol rol)
        {
            return await rolRepositorio.UpdateAsync(rol);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await rolRepositorio.DeleteAsync(id);
        }
    }
}
