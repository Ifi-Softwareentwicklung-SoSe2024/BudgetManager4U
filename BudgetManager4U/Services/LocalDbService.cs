using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SQLite;
using TransactionScheduler.Models;

namespace TransactionScheduler.Services;

public class LocalDbService
{
    private const string DbName = "transaction_database.db3";
    private readonly SQLiteAsyncConnection _connection;
    
    public LocalDbService()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<TransactionClass>();
    }

    public async Task<List<TransactionClass>> GetTransactions()
    {
        
            return await _connection.Table<TransactionClass>().ToListAsync();
    
        
    }

    public async Task<string?> GetBalance()
    {
        List<TransactionClass> transactions = await GetTransactions();
       string? balance ;
        balance =  Convert.ToString(transactions.Sum(x => x.TransactionAmount));
   
        return balance;
    }

    public async Task<List<TransactionClass>> GetExpenses()
    {
        
            return await _connection.Table<TransactionClass>().Where(x => x.TransactionAmount<0).ToListAsync(); 
         


    }

    public async Task<List<TransactionClass>> GetIncomes()
    {
     
            return await _connection.Table<TransactionClass>().Where(x => x.TransactionAmount > 0).ToListAsync();
      
        
        
    }



    public async Task<TransactionClass> GetTransaction(int TransactionId)
    {
        return await _connection.Table<TransactionClass>().Where(x => x.Id == TransactionId).FirstOrDefaultAsync();
    }
    public async Task AddTransaction(TransactionClass transaction)
    {
         
        try {
            
            
                    await _connection.InsertAsync(transaction);
            }
           

        catch(ArgumentException e) {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public async Task UpdateTransaction(TransactionClass transaction)
    {
        try {
            await _connection.UpdateAsync(transaction);
        }
               catch(ArgumentException e) {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public async Task DeleteTransaction(TransactionClass transaction)
    {
        await _connection.DeleteAsync(transaction);
    }


    

}
