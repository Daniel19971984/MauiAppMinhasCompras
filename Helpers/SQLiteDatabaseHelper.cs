using MauiAppMinhasCompras.Models;
using SQLite;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;
        public SQLiteDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<Produto>().Wait();
        }

        public Task<int> insert(Produto p)
        {
            return _connection.InsertAsync(p);
        }

        public Task<List<Produto>> Update(Produto p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=?, WHERE ID=?";
           return _connection.QueryAsync<Produto>(sql, p.Descricao, p.Preco, p.Id);
        }


        public Task<int> delete(int id) 
        {
         return _connection.Table<Produto>().DeleteAsync(i  => i.Id == id);

        }
        public Task<List<Produto>> GetAll() 
        {
            return _connection.Table<Produto>().ToListAsync();
        }

        public Task<List<Produto>> Search (string query) 
        {
            string sql = "SELECT * Produto where descricao LIKE '%" + q + "%'";
            return _connection.QueryAsync<Produto> (sql);
        }

    }
}
