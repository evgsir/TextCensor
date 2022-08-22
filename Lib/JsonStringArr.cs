namespace Censor01;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

public class JsonStringArr
{
    static JsonSerializerOptions _options = new JsonSerializerOptions()
    {
        AllowTrailingCommas = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All), 
        WriteIndented = true
    };
    
    public static void Export(string path, string[] words)
    {
        var file = new FileStream(path , FileMode.OpenOrCreate, FileAccess.Write);
        JsonSerializer.SerializeAsync(file, words, _options);
        file.Close();
    }

    public static string[] Import(string path)
    {
        using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
        var newBadWords = JsonSerializer.DeserializeAsync<string[]>(file).Result;
        file.Close();
        return newBadWords;
    }
}