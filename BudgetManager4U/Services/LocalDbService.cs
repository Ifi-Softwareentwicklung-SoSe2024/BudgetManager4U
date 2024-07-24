using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SQLite;
using BudgetManager4U.Models;


namespace BudgetManager4U.Services;
/// <summary>
/// Database service of the class <c>LocalDbService</c>  for the data manipulation 
/// </summary>

public class LocalDbService
{
    private const string DbName = "transaction_database.db3";
    private readonly SQLiteAsyncConnection _connection;


    /// <summary>
    /// Constuctor of the <c>LocalDbService</c> service
    /// </summary>
    public LocalDbService()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<TransactionClass>();
    }

    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving all records
    /// from the table "Transactions" in the ascending order(by date)
    /// </summary>
    /// <returns>The  list of the TransactionClass sorted by date</returns>
    public async Task<List<TransactionClass>> GetTransactions()
    {

        return await _connection.Table<TransactionClass>().OrderBy(x => x.Datum).ToListAsync();


    }
    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving the current balance
    /// </summary>
    /// <returns>The string value of the current balance </returns>
    public async Task<string?> GetBalance()
    {
        List<TransactionClass> transactions = await GetTransactions();

        var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        var balance = transactions.Sum(x => x.TransactionAmount).ToString("C", culture);
        return balance;
    }

    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving all expenses from the table "Transactions" in ascending order (by date)
    /// </summary>
    /// <returns>The filtered list of the TransactionClass</returns>
    public async Task<List<TransactionClass>> GetExpenses()
    {

        return await _connection.Table<TransactionClass>().Where(x => x.TransactionAmount < 0).OrderBy(x => x.Datum).ToListAsync();



    }
    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving all incomes from the table "Transactions" in the ascending order(by date)
    /// </summary>
    /// <returns>The filtered list of the TransactionClass</returns>
    public async Task<List<TransactionClass>> GetIncomes()
    {

        return await _connection.Table<TransactionClass>().Where(x => x.TransactionAmount > 0).OrderBy(x=>x.Datum).ToListAsync();



    }

    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving all expenses from the table "Transactions" in the ascending order(by date)
    /// within the defined period
    /// </summary>
    /// <param name="dateFrom"> Starting date of DateTime type</param>
    /// <param name="dateTo"> Starting date of DateTime type</param>
    /// <returns>The filtered list of the TransactionClass</returns>
    public async Task<List<TransactionClass>> GetExpensesByDate(DateTime dateFrom, DateTime dateTo)
    {
        return await _connection.Table<TransactionClass>().Where(x => (x.Datum >= dateFrom & x.Datum <= dateTo &x.TransactionAmount<0)).OrderBy(x => x.Datum).ToListAsync();

    }

    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for retrieving all incomes from the table "Transactions" in the ascending order(by date)
    /// within the defined period
    /// </summary>
    /// <param name="dateFrom"> Starting date of DateTime type</param>
    /// <param name="dateTo"> Starting date of DateTime type</param>
    /// <returns>The filtered list of the TransactionClass</returns>
    public async Task<List<TransactionClass>> GetIncomesByDate(DateTime dateFrom, DateTime dateTo)
    {
        return await _connection.Table<TransactionClass>().Where(x =>(x.Datum >= dateFrom & x.Datum <= dateTo & x.TransactionAmount > 0)).OrderBy(x => x.Datum).ToListAsync();
       
    }

    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for inserting the transaction record in the database
    /// </summary>
    ///  <param name="transaction"> transaction of the TransactionClass </param>
   /// <exception cref="ArgumentException">
        /// Thrown when the arguments are invalid.
        /// </exception>
        ///    /// <exception cref="Exception">
        /// Thrown when the unknown failure occurs
        /// </exception>
    public async Task AddTransaction(TransactionClass transaction)
    {
        
        try
        {


            await _connection.InsertAsync(transaction);
        }


        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }
    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for updating the transaction record in the database
    /// </summary>
    ///  <param name="transaction"> transaction of the TransactionClass </param>
    /// <exception cref="ArgumentException">
        /// Thrown when the arguments are invalid.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown when the unknown failure occurs
        /// </exception>
    public async Task UpdateTransaction(TransactionClass transaction)
    {
        
        try
        {
            await _connection.UpdateAsync(transaction);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// Method of the  <c>LocalDbService</c> service for deleting the transaction record from the database
    /// </summary>
    ///  <param name="transaction"> transaction of the TransactionClass </param>

    public async Task DeleteTransaction(TransactionClass transaction)
    {
        await _connection.DeleteAsync(transaction);
    }




}
