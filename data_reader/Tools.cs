using System.Net;
using System.Text;

namespace Tools;

public class DataReader
{
    private string folderPath = @"C:\dev\advent_of_code_2024\data\";
    public async Task<string> read_data(string path = "")
    {
        var data = check_if_data_exists(path);
        if (data != "")
        {
            return data;
        }

        using var client = new HttpClient();
        var cookie = File.ReadAllText("cookie.369");

        client.DefaultRequestHeaders.Add("Cookie", cookie);
        var result = await client.GetStringAsync(path);

        write_data(path, result);

        return result;
    }

    private void write_data(string path, string data)
    {
        var result = string.Concat(path.Where(char.IsDigit));
        Console.WriteLine(result);

        Directory.CreateDirectory(folderPath);

        // Convert to CRLF line endings
        data = data.Replace("\n", "\r\n").Replace("\r\r\n", "\r\n").TrimEnd();
        File.WriteAllText(Path.Combine(folderPath, result), data, new UTF8Encoding(false));
    }

    private string check_if_data_exists(string path)
    {
        var result = string.Concat(path.Where(char.IsDigit));
        var filePath = Path.Combine(folderPath, result);

        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        else
        {
            return "";
        }
    }
}