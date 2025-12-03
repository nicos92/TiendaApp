using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Contrato.IServicio;
using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using TiendaApp.Utilidad;

namespace TiendaApp.Servicio.Dominio
{
    public class UsuarioServicio(IUsuarioRepositorio usuarioRepositorio) : IUsuarioServicio
    {
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await usuarioRepositorio.GetAllAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await usuarioRepositorio.GetByIdAsync(id);
        }

        public async Task<Usuario?> GetByNameAsync(string nombre)
        {
            return await usuarioRepositorio.GetByNameAsync(nombre);
        }

        public async Task<Usuario?> GetByDNIAsync(string dni)
        {
            return await usuarioRepositorio.GetByDNIAsync(dni);
        }

        public async Task<int> CreateAsync(Usuario usuario)
        {
            usuario.Password = PasswordHasher.Hash(usuario.Password);
            return await usuarioRepositorio.CreateAsync(usuario);
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            return await usuarioRepositorio.UpdateAsync(usuario);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await usuarioRepositorio.DeleteAsync(id);
        }

        public async Task<Usuario?> ValidateCredentialsAsync(string nombre, string password)
        {
            var usuario = await usuarioRepositorio.GetByNameAsync(nombre);
            if (usuario != null && PasswordHasher.Verify(password, usuario.Password))
            {
                return usuario;
            }
            return null;
        }
    }
}
