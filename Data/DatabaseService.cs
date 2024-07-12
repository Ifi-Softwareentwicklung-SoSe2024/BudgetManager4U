using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BudgetManager4U.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BudgetManager.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}
