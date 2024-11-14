using Alb.Function.Domain.Repositories;
//using Dapper;
using System.Data;

namespace Alb.Function.Infraestructure.Database.Dapper.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDbConnection _dbConnection;



        public GenericRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;

        }


        public async Task<int> AddAsync(T entity)
        {
            var table = typeof(T).Name;
            var query = $"INSERT INTO {table} VALUES (@Entity);";
            var result = 0; //await _dbConnection.ExecuteAsync(query, entity);
            return result;
        }


        public async Task<int> DeleteAsync(int id)
        {
            var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";
            return 1; // await _dbConnection.ExecuteAsync(query, new { Id = id });
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {typeof(T).Name}";
            return null; // await _dbConnection.QueryAsync<T>(query);            
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {typeof(T).Name} WHERE Id = @Id";
            return null;//await _dbConnection.QueryFirstOrDefaultAsync<T>(query, new { Id = id });
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var query = $"UPDATE {typeof(T).Name} SET /* Propiedades */ WHERE Id = @Id"; // Definir propiedades específicas
            return 0; // await _dbConnection.ExecuteAsync(query, entity);
        }
    }
}
