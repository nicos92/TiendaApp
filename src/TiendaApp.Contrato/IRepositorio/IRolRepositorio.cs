using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IRolRepositorio
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol?> GetByNameAsync(string nombre);
        Task<int> CreateAsync(Rol rol);
        Task<bool> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}
