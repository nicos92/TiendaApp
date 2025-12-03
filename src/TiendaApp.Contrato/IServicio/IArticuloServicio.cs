using TiendaApp.Modelo.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TiendaApp.Contrato.IServicio
{
    public interface IArticuloServicio
    {
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task<Articulo?> GetByNameAsync(string nombre);
        Task<int> CreateAsync(Articulo articulo);
        Task<bool> UpdateAsync(Articulo articulo);
        Task<bool> DeleteAsync(int id);
    }
}