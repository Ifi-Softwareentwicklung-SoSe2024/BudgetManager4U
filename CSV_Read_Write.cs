using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Maui.Storage;

static class BudgetCsvReader
{
    public static List<BudgetItem> ReadCsv(string path)
    {
        var lines = FileSystem.AppPackage.File.ReadAllLinesAsync(path).Result;

        if (lines.Length == 0)
        {
            throw new FormatException("CSV-Datei ist leer!");
        }

        var budgetItems = new List<BudgetItem>();

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');

            if (values.Length != 4)
            {
                throw new FormatException("CSV-Datei hat nicht die erwartete Anzahl von Spalten.");
            }

            var budgetItem = new BudgetItem
            {
                Date = DateTime.Parse(values[0].Trim()),
                Category = values[1].Trim(),
                Description = values[2].Trim(),
                Amount = decimal.Parse(values[3].Trim())
            };

            budgetItems.Add(budgetItem);
        }

        return budgetItems;
    }
}

static class BudgetCsvWriter
{
    public static void WriteCsv(string path, List<BudgetItem> budgetItems)
    {
        var lines = new List<string> { "Date,Category,Description,Amount" };

        foreach (var item in budgetItems)
        {
            lines.Add($"{item.Date:yyyy-MM-dd},{item.Category},{item.Description},{item.Amount}");
        }

        FileSystem.AppPackage.File.WriteAllLinesAsync(path, lines).Wait();
    }
}

public class BudgetItem
{
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
}
