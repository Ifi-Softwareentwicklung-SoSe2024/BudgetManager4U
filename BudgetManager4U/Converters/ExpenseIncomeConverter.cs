using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager4U.Converters;
/// <summary>
///The helper class <c>ExpenseIncomeConverter</c> using the interface <c> IValueConverter</c>
/// </summary>
public class ExpenseIncomeConverter : IValueConverter
{
    /// <summary>
    ///The method  class <c>ExpenseIncomeConverter</c> that changes background 
    ///depening on <c>TransactionAmount</c> of the <c>Transactionclass</c> instance
    /// </summary>
    /// <param name="value"> value of TotalAmount </param>
    ///  <param name="targetType"> value of TotalAmount </param>
    /// <param name="parameter"> Color of listview.item.backgroundcolor </param>
    /// <param name="culture"> some culture info </param>
    /// <returns>The Type of System.Colors</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((decimal)value! > 0)
        {
            return Colors.PaleGreen;
        }
        else
        {
            return Colors.LightCoral;
        }


    }
    /// <summary>
    /// neither used nor  implented
    /// </summary>
    
    /// <exception cref="NotImplementedException">
    /// Thrown when the ConvertBack is not defined and implemented 
    /// </exception>
    /// <param name="value"> value of TotalAmount </param>
    ///  <param name="targetType"> value of TotalAmount </param>
    /// <param name="parameter"> Color of listview.item.backgroundcolor </param>
    /// <param name="culture"> some culture info </param>
   
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        throw new NotImplementedException();
}

