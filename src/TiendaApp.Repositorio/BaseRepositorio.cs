using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;
using TiendaApp.Repositorio.DataInit;

namespace TiendaApp.Repositorio
{
    public abstract class BaseRepositorio
    {
        protected readonly string _connectionString;

        protected BaseRepositorio()
        {
            _connectionString = $"Data Source={PathHelper.GetDatabasePath()}";
        }

        protected async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            return await connection.QueryFirstOrDefaultAsync<T>(sql,
                                                                param,
                                                                transaction,
                                                                commandTimeout);
        }

        protected async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout);
        }

        protected async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            return await connection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout);
        }

        protected async Task ExecuteAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(sql, param, transaction, commandTimeout);
        }

        protected async Task<int> ExecuteScalarAsync(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null)
        {
            using var connection = new SqliteConnection(_connectionString);
            return await connection.ExecuteScalarAsync<int>(sql, param, transaction, commandTimeout);
        }

        protected IDbConnection CreateConnection()
        {
            return new SqliteConnection(_connectionString);
        }
    }
}
