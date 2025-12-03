using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IServicio
{
    public interface IRolServicio
    {
        Task<IEnumerable<Rol>> GetAllAsync();
        Task<Rol?> GetByIdAsync(int id);
        Task<Rol?> GetByNameAsync(string nombre);
        Task<int> CreateAsync(Rol rol);
        Task<bool> UpdateAsync(Rol rol);
        Task<bool> DeleteAsync(int id);
    }
}