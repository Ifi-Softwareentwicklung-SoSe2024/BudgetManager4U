using System.Collections.Generic;   //Provides the 'List<T> collection class sued for the storing of transactions
using System.IO;                    //Provides necessary 'StremWriter' for writing data to files
using BudgetManager4U.Models;       // Contains 'TransactionClass'

public static class CsvWriter
{

    // Method to write transactions into a CSV file
    public static void WriteTransactionsToCsv(List<TransactionClass> transactions, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Date,Description,TransactionAmount");     // Labeling the output (header)

            foreach (var transaction in transactions)
            {
                // formating and writing the transaction data (single line) to the CSV file
                writer.WriteLine($"{transaction.Datum:d},{transaction.Description},{transaction.TransactionAmount}"); 
            }
        }
    }
}


