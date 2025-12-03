using TiendaApp.Modelo.Entities;

namespace TiendaApp.Contrato.IRepositorio
{
    public interface IUsuarioRolRepositorio
    {
        Task<IEnumerable<UsuarioRol>> GetAllAsync();
        Task<UsuarioRol?> GetByIdAsync(int usuarioId, int rolId);
        Task<IEnumerable<UsuarioRol>> GetByUsuarioIdAsync(int usuarioId);
        Task<IEnumerable<UsuarioRol>> GetByRolIdAsync(int rolId);
        Task<int> CreateAsync(UsuarioRol usuarioRol);
        Task<bool> UpdateAsync(UsuarioRol usuarioRol);
        Task<bool> DeleteAsync(int usuarioId, int rolId);
    }
}
