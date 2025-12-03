using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class UsuarioRolRepositorio : BaseRepositorio, IUsuarioRolRepositorio
    {
        public async Task<IEnumerable<UsuarioRol>> GetAllAsync()
        {
            const string sql = "SELECT UsuarioId, RolId FROM UsuariosRoles";
            using var connection = CreateConnection();
            return await connection.QueryAsync<UsuarioRol>(sql);
        }

        public async Task<UsuarioRol?> GetByIdAsync(int usuarioId, int rolId)
        {
            const string sql = "SELECT UsuarioId, RolId FROM UsuariosRoles WHERE UsuarioId = @UsuarioId AND RolId = @RolId";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<UsuarioRol>(sql, new { UsuarioId = usuarioId, RolId = rolId });
        }

        public async Task<IEnumerable<UsuarioRol>> GetByUsuarioIdAsync(int usuarioId)
        {
            const string sql = "SELECT UsuarioId, RolId FROM UsuariosRoles WHERE UsuarioId = @UsuarioId";
            using var connection = CreateConnection();
            return await connection.QueryAsync<UsuarioRol>(sql, new { UsuarioId = usuarioId });
        }

        public async Task<IEnumerable<UsuarioRol>> GetByRolIdAsync(int rolId)
        {
            const string sql = "SELECT UsuarioId, RolId FROM UsuariosRoles WHERE RolId = @RolId";
            using var connection = CreateConnection();
            return await connection.QueryAsync<UsuarioRol>(sql, new { RolId = rolId });
        }

        public async Task<int> CreateAsync(UsuarioRol usuarioRol)
        {
            const string sql = "INSERT INTO UsuariosRoles (UsuarioId, RolId) VALUES (@UsuarioId, @RolId); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, usuarioRol);
        }

        public async Task<bool> UpdateAsync(UsuarioRol usuarioRol)
        {
            const string sql = "UPDATE UsuariosRoles SET UsuarioId = @UsuarioId, RolId = @RolId WHERE UsuarioId = @UsuarioId AND RolId = @RolId";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, usuarioRol);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int usuarioId, int rolId)
        {
            const string sql = "DELETE FROM UsuariosRoles WHERE UsuarioId = @UsuarioId AND RolId = @RolId";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { UsuarioId = usuarioId, RolId = rolId });
            return result > 0;
        }
    }
}