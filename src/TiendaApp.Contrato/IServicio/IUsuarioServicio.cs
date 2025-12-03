using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IServicio
{
    public interface IUsuarioServicio
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByNameAsync(string nombre);
        Task<Usuario?> GetByDNIAsync(string dni);
        Task<int> CreateAsync(Usuario usuario);
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
        Task<Usuario?> ValidateCredentialsAsync(string nombre, string password);
    }
}