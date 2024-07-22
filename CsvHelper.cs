using System.Globalization;
using System.Text;

public static class CsvHelper
{
    public static string ConvertTransactionsToCsv(List<Transaction> transactions)
    {
        var csvBuilder = new StringBuilder();
        csvBuilder.AppendLine("Id,Value,Date,Description");

        foreach (var transaction in transactions)
        {
            var line = $"{transaction.Id},{transaction.Value.ToString(CultureInfo.InvariantCulture)},{transaction.Date.ToString("yyyy-MM-dd")},{transaction.Description}";
            csvBuilder.AppendLine(line);
        }

        return csvBuilder.ToString();
    }
}