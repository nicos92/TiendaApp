using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Contrato.IRepositorio;
using TiendaApp.Modelo.Entities;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio.Repositorios
{
    public class VentaRepositorio : BaseRepositorio, IVentaRepositorio
    {
        public async Task<IEnumerable<Venta>> GetAllAsync()
        {
            const string sql = "SELECT Id, Fecha FROM Ventas";
            using var connection = CreateConnection();
            return await connection.QueryAsync<Venta>(sql);
        }

        public async Task<Venta?> GetByIdAsync(int id)
        {
            const string sql = "SELECT Id, Fecha FROM Ventas WHERE Id = @Id";
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<Venta>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Venta venta)
        {
            const string sql = "INSERT INTO Ventas (Fecha) VALUES (@Fecha); SELECT last_insert_rowid();";
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, venta);
        }

        public async Task<bool> UpdateAsync(Venta venta)
        {
            const string sql = "UPDATE Ventas SET Fecha = @Fecha WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, venta);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string sql = "DELETE FROM Ventas WHERE Id = @Id";
            using var connection = CreateConnection();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }
    }
}