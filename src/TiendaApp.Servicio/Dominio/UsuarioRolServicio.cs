using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Servicio.Dominio
{
    public class UsuarioRolServicio(IUsuarioRolRepositorio usuarioRolRepositorio) : IUsuarioRolServicio
    {
        public async Task<IEnumerable<UsuarioRol>> GetAllAsync()
        {
            return await usuarioRolRepositorio.GetAllAsync();
        }

        public async Task<UsuarioRol?> GetByIdAsync(int usuarioId, int rolId)
        {
            return await usuarioRolRepositorio.GetByIdAsync(usuarioId, rolId);
        }

        public async Task<IEnumerable<UsuarioRol>> GetByUsuarioIdAsync(int usuarioId)
        {
            return await usuarioRolRepositorio.GetByUsuarioIdAsync(usuarioId);
        }

        public async Task<IEnumerable<UsuarioRol>> GetByRolIdAsync(int rolId)
        {
            return await usuarioRolRepositorio.GetByRolIdAsync(rolId);
        }

        public async Task<int> CreateAsync(UsuarioRol usuarioRol)
        {
            return await usuarioRolRepositorio.CreateAsync(usuarioRol);
        }

        public async Task<bool> UpdateAsync(UsuarioRol usuarioRol)
        {
            return await usuarioRolRepositorio.UpdateAsync(usuarioRol);
        }

        public async Task<bool> DeleteAsync(int usuarioId, int rolId)
        {
            return await usuarioRolRepositorio.DeleteAsync(usuarioId, rolId);
        }
    }
}
