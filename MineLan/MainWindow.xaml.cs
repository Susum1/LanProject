using System.Windows;
using MineLAN.Services;
using System.IO;

namespace MineLAN;

public partial class MainWindow : Window
{
    private readonly ApplicationController _controller;

    public MainWindow()
    {
        InitializeComponent();

        _controller = new ApplicationController();

        var profile = new MineLAN.Models.WireGuardProfile
        {
            Name = "TestProfile",
            PrivateKey = "PRIVATE_KEY",
            PublicKey = "PUBLIC_KEY",
            Address = "10.100.0.2/24",
            Endpoint = "127.0.0.1:51820"
        };

        _controller.Services.ProfileManager.Add(profile);

        string config =
           _controller.Services.Config.Build(profile);

        File.WriteAllText(
            Path.Combine(
                _controller.Services.FileSystem.TempFolder,
                profile.Name + ".conf"),
            config);

        ProfilesList.Items.Clear();

        foreach (var p in _controller.Services.ProfileManager.Items)
        {
            ProfilesList.Items.Add(p.Name);
        }

        bool imported =
        _controller.Services.Import.Import(
            Path.Combine(
                _controller.Services.FileSystem.TempFolder,
                profile.Name + ".conf"));

        MessageBox.Show(
            imported
                ? "Конфигурация передана WireGuard"
                : "WireGuard не найден");

        MessageBox.Show(config);

        ApplicationTitle.Text = _controller.ApplicationName;
        VersionText.Text = _controller.Version;
        StatusText.Text = "🟢 " + _controller.Status;

        var info = _controller.Services.Diagnostics.GetSystemInfo();

        InternetText.Text = info.HasInternet
            ? "🟢 Интернет доступен"
            : "🔴 Интернет недоступен";

        AdminText.Text = info.IsAdministrator
            ? "🟢 Запущено от администратора"
            : "🟡 Запущено без прав администратора";

        WireGuardText.Text = info.WireGuardInstalled
            ? "🟢 WireGuard установлен"
            : "🔴 WireGuard не установлен";

        SystemInfoText.Text =
              $"Пользователь: {info.UserName}\n" +
              $"Компьютер: {info.MachineName}\n" +
              $"Windows: {info.WindowsVersion}";

        WireGuardVersionText.Text =
              $"WireGuard: {info.WireGuardVersion}";

        WireGuardPathText.Text =
              $"Путь: {info.WireGuardPath ?? "не найден"}";

        PathText.Text = _controller.Services.FileSystem.RootFolder;
    }
}