using System.IO;
using MineLAN.Models;
using MineLAN.Services;

namespace MineLAN.Controllers;

public class MainWindowController
{
    private readonly MainWindow _window;

    private readonly ApplicationController _app;

    private readonly ProfileFactory _factory = new();

    public MainWindowController(MainWindow window)
    {
        _window = window;
        _app = new ApplicationController();
    }

    public void Initialize()
    {
        _app.Initialize();

        LoadApplicationInfo();

        LoadDiagnostics();

        RefreshProfiles();
    }

    public void CreateProfile()
    {
        int index = _app.Services.ProfileManager.Items.Count + 1;

        ProfileCreateModel model = new()
        {
            Name = $"Profile {index}",

            Address = $"10.100.0.{index + 1}/24",

            Endpoint = "0.0.0.0:51820"
        };

        var profile = _factory.Create(model);

        _app.Services.ProfileManager.Add(profile);

        RefreshProfiles();

        _app.Services.Logger.Write($"Создан профиль {profile.Name}");
    }

    public void DeleteSelectedProfile()
    {
        if (_window.ProfilesList.SelectedItem == null)
            return;

        string name = _window.ProfilesList.SelectedItem.ToString()!;

        _app.Services.ProfileManager.Remove(name);

        RefreshProfiles();

        _app.Services.Logger.Write($"Удалён профиль {name}");
    }

    private void RefreshProfiles()
    {
        _window.ProfilesList.Items.Clear();

        foreach (var profile in _app.Services.ProfileManager.Items)
            _window.ProfilesList.Items.Add(profile.Name);
    }

    private void LoadApplicationInfo()
    {
        _window.ApplicationTitle.Text = _app.ApplicationName;
        _window.VersionText.Text = _app.Version;
        _window.StatusText.Text = "🟢 " + _app.Status;
        _window.PathText.Text = _app.Services.FileSystem.RootFolder;
    }

    private void LoadDiagnostics()
    {
        var info = _app.Services.Diagnostics.GetSystemInfo();

        _window.InternetText.Text = info.HasInternet
            ? "🟢 Интернет доступен"
            : "🔴 Интернет недоступен";

        _window.AdminText.Text = info.IsAdministrator
            ? "🟢 Запущено от администратора"
            : "🟡 Без прав администратора";

        _window.WireGuardText.Text = info.WireGuardInstalled
            ? "🟢 WireGuard установлен"
            : "🔴 WireGuard отсутствует";

        _window.SystemInfoText.Text =
            $"Пользователь: {info.UserName}\nКомпьютер: {info.MachineName}\nWindows: {info.WindowsVersion}";

        _window.WireGuardVersionText.Text = $"WireGuard: {info.WireGuardVersion}";
        _window.WireGuardPathText.Text = $"Путь: {info.WireGuardPath ?? "не найден"}";
    }
}