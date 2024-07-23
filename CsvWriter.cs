using System.Collections.Generic;
using System.IO;
using BudgetManager4U.Models;

public static class CsvWriter
{
    public static void WriteTransactionsToCsv(List<TransactionClass> transactions, string filePath)
    {
        using (var writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Date,Description,TransactionAmount");

            foreach (var transaction in transactions)
            {
                writer.WriteLine($"{transaction.Datum:d},{transaction.Description},{transaction.TransactionAmount}");
            }
        }
    }
}


