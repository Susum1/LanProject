using System.IO;
using MineLAN.Models;

namespace MineLAN.Services;

public class ProfileService
{
    private readonly FileSystemService _fs;

    private readonly JsonService _json;

    public ProfileService(
        FileSystemService fs,
        JsonService json)
    {
        _fs = fs;
        _json = json;
    }

    public void Save(WireGuardProfile profile)
    {
        string file =
            Path.Combine(
                _fs.ProfilesFolder,
                profile.Name + ".json");

        _json.Save(file, profile);
    }

    public List<WireGuardProfile> LoadAll()
    {
        List<WireGuardProfile> list = new();

        foreach (string file in Directory.GetFiles(_fs.ProfilesFolder, "*.json"))
        {
            WireGuardProfile? profile =
                _json.Load<WireGuardProfile>(file);

            if (profile != null)
                list.Add(profile);
        }

        return list;
    }
}