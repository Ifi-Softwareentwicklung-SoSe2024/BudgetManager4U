using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager4U.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using SQLite;
namespace BudgetManager4U.Service;

public class UserService : BaseService
{
    protected readonly DatabaseContext dbContext;
    public UserService(DatabaseContext dbContext): base(dbContext)
    {
       
    }

    public async Task<UserAccountClass> GetUserByEmailAndPassword(string email, string password)
    {
        try
        {
            return await dbContext.DatabaseConnection.Table<UserAccountClass>().Where(x => x.Email == email && x.Password == password).FirstAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }

        return null;
    }

    public async Task<UserAccountClass> UpdateUser(UserAccountClass user)
    {
        try
        {
            await dbContext.DatabaseConnection.UpdateAsync(user);

           
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }

        return null;
    }

    public async Task<UserAccountClass> InsertUserAccount(UserAccountClass user)
    {
        try
        {
             await dbContext.DatabaseConnection.InsertAsync(user);
            return user;

        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }
        return null;
    }
        public async Task<List<UserAccountClass>> GetUsers()
        {
            try
            {
                return await dbContext.DatabaseConnection.Table<UserAccountClass>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
        }
        return null ;
    }

        public async Task<UserAccountClass> DeleteInvoice(UserAccountClass user)
        {
            try
            {
                await dbContext.DatabaseConnection.DeleteAsync(user);

                
            }
            catch (Exception ex)
            {
                StatusMessage = $"Failed to retrieve data. {ex.Message}";
            }

            return null;
        }


    }




