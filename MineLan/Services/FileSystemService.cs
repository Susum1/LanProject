using System;
using System.IO;

namespace MineLAN.Services;

public class FileSystemService
{
    public string RootFolder =>
        Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MineLAN");

    public string ProfilesFolder =>
    Path.Combine(RootFolder, "Profiles");

    public string TempFolder =>
        Path.Combine(RootFolder, "Temp");

    public string LogFolder =>
        Path.Combine(RootFolder, "Logs");

    public string ConfigFile =>
        Path.Combine(RootFolder, "config.json");

    public void Initialize()
    {
        Directory.CreateDirectory(RootFolder);
        Directory.CreateDirectory(LogFolder);
        Directory.CreateDirectory(ProfilesFolder);
        Directory.CreateDirectory(TempFolder);
    }
}