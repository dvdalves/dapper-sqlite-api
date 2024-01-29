using CRUD_DapperSqlite.Models;
using Dapper;
using System.Data;

namespace CRUD_DapperSqlite.Data
{
    public class Context
    {
        private readonly IDbConnection _connection;

        public Context(IDbConnection connection)
        {
            _connection = connection;
        }

        public void EnsureTablesCreated()
        {
            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Product (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Price REAL NOT NULL
                );";

            _connection.Execute(createTableSql);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _connection.QueryAsync<Product>("SELECT * FROM Product");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _connection.QueryFirstOrDefaultAsync<Product>("SELECT * FROM Product WHERE Id = @Id", new { Id = id });
            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {id} not found.");
            }
            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var sql = @"
                INSERT INTO Product (Name, Price)
                VALUES (@Name, @Price);
                SELECT last_insert_rowid()";

            var id = await _connection.QuerySingleAsync<int>(sql, product);
            product.Id = id;

            return product;
        }

        public async Task UpdateProductAsync(Product product)
        {
            var sql = @"
                UPDATE Product
                SET Name = @Name, Price = @Price
                WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var sql = "DELETE FROM Product WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
