using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Data.Sqlite;
using BudgetManager4U.Models;

using SQLite;
namespace BudgetManager4U.Service;




public class DatabaseContext
{

    public SQLiteAsyncConnection? DatabaseConnection;//_connection

    

}

/*
 * public DatabaseContext()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,db_name));
        _connection.CreateTableAsync<UserAccountClass>();
    }

    public async Task<List<UserAccountClass>> GetUsers()
    {
        return await _connection.Table<UserAccountClass>().ToListAsync();
    }

    public async Task<UserAccountClass> GetUserByEmailAndPassword(string email, string password)
    {
        return await _connection.Table<UserAccountClass>().Where(x => x.Email == email && x.Password == password).FirstAsync();
    }

    public async Task CreateUserAccount(UserAccountClass user)
    {
        await _connection.InsertAsync(user);
    }

    public async Task EditUserAccount(UserAccountClass user)
    {
        await _connection.UpdateAsync(user);
    }
*/