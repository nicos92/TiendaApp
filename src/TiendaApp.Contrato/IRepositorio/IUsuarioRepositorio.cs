using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<Usuario?> GetByIdAsync(int id);
        Task<Usuario?> GetByNameAsync(string nombre);
        Task<Usuario?> GetByDNIAsync(string dni);
        Task<int> CreateAsync(Usuario usuario);
        Task<bool> UpdateAsync(Usuario usuario);
        Task<bool> DeleteAsync(int id);
    }
}
