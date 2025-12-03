using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IArticuloRepositorio
    {
        Task<IEnumerable<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task<Articulo?> GetByNameAsync(string nombre);
        Task<int> CreateAsync(Articulo articulo);
        Task<bool> UpdateAsync(Articulo articulo);
        Task<bool> DeleteAsync(int id);
    }
}
