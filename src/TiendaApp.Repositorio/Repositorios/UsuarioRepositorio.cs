using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
    {
        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            const string sql = "SELECT Id, Nombre, Apellido, DNI, Password FROM Usuarios";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Usuario>(sql);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Nombre, Apellido, DNI, Password FROM Usuarios WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Id = id });
        }

        public async Task<Usuario?> GetByNameAsync(string nombre)
        {
            const string sql = "SELECT Id, Nombre, Apellido, DNI, Password FROM Usuarios WHERE Nombre = @Nombre";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { Nombre = nombre });
        }

        public async Task<Usuario?> GetByDNIAsync(string dni)
        {
            const string sql = "SELECT Id, Nombre, Apellido, DNI, Password FROM Usuarios WHERE DNI = @DNI";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new { DNI = dni });
        }

        public async Task<int> CreateAsync(Usuario usuario)
        {
            const string sql = "INSERT INTO Usuarios (Nombre, Apellido, DNI, Password) VALUES (@Nombre, @Apellido, @DNI, @Password); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, usuario);
        }

        public async Task<bool> UpdateAsync(Usuario usuario)
        {
            const string sql = "UPDATE Usuarios SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Password = @Password WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, usuario);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Usuarios WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}