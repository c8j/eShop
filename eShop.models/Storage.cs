using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace eShop.models;

public class Storage
{

    private static readonly JsonSerializerOptions s_options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true
    };

    // 1. Skapa en static metod för att spara ner objekt till json...
    public static void WriteJson<T>(string path, List<T> data)
    {
        var json = JsonSerializer.Serialize(data, s_options);
        File.WriteAllText(path, json);
    }

    public static List<T>? ReadJson<T>(string path)
    {
        var json = File.ReadAllText(path);
        List<T>? data = JsonSerializer.Deserialize<List<T>>(json, s_options);
        return data;
    }
}
