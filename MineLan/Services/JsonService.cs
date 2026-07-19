using System.IO;
using System.Text.Json;

namespace MineLAN.Services;

public class JsonService
{
    public void Save<T>(string file, T obj)
    {
        string json = JsonSerializer.Serialize(obj,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(file, json);
    }

    public T? Load<T>(string file)
    {
        if (!File.Exists(file))
            return default;

        string json = File.ReadAllText(file);

        return JsonSerializer.Deserialize<T>(json);
    }
}