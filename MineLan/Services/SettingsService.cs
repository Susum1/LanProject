using System.Text.Json;
using MineLAN.Models;
using System.IO;

namespace MineLAN.Services;

public class SettingsService
{
    private readonly FileSystemService _fileSystem;

    public AppSettings Settings { get; private set; } = new();

    public SettingsService(FileSystemService fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Load()
    {
        if (!File.Exists(_fileSystem.ConfigFile))
        {
            Save();
            return;
        }

        string json = File.ReadAllText(_fileSystem.ConfigFile);

        Settings =
            JsonSerializer.Deserialize<AppSettings>(json)
            ?? new AppSettings();
    }

    public void Save()
    {
        string json =
            JsonSerializer.Serialize(
                Settings,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });

        File.WriteAllText(_fileSystem.ConfigFile, json);
    }
}