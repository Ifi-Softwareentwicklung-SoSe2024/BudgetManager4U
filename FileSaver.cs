using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

public static class FileSaver
{
    public static async Task SaveCsvToFileAsync(string csvContent, string fileName)
    {
        var filePath = Path.Combine(FileSystem.Current.AppDataDirectory, fileName);
        await File.WriteAllTextAsync(filePath, csvContent);
    }
}

