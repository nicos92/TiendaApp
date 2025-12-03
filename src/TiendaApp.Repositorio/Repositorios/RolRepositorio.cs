using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class RolRepositorio : BaseRepositorio, IRolRepositorio
    {
        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            const string sql = "SELECT Id, Nombre FROM Roles";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Rol>(sql);
        }

        public async Task<Rol?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Nombre FROM Roles WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Rol>(sql, new { Id = id });
        }

        public async Task<Rol?> GetByNameAsync(string nombre)
        {
            const string sql = "SELECT Id, Nombre FROM Roles WHERE Nombre = @Nombre";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Rol>(sql, new { Nombre = nombre });
        }

        public async Task<int> CreateAsync(Rol rol)
        {
            const string sql = "INSERT INTO Roles (Nombre) VALUES (@Nombre); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, rol);
        }

        public async Task<bool> UpdateAsync(Rol rol)
        {
            const string sql = "UPDATE Roles SET Nombre = @Nombre WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, rol);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Roles WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}