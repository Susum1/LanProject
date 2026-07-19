using MineLAN.Models;
using System.IO;
using System.Text.Json;

namespace MineLAN.Services;

public class ProfileManager
{
    private readonly ProfileService _profiles;

    private readonly List<WireGuardProfile> _items = new();

    public IReadOnlyList<WireGuardProfile> Items => _items;

    public ProfileManager(ProfileService profiles)
    {
        _profiles = profiles;

        Reload();
    }

    public void Reload()
    {
        _items.Clear();

        _items.AddRange(_profiles.LoadAll());
    }

    public void Add(WireGuardProfile profile)
    {
        _profiles.Save(profile);

        Reload();
    }

    public void Remove(string name)
    {
        string file =
            Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.ApplicationData),
                "MineLAN",
                "Profiles",
                name + ".json");

        if (File.Exists(file))
            File.Delete(file);

        Reload();
    }
}