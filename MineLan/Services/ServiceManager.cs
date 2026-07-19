namespace MineLAN.Services;

public class ServiceManager
{
    public FileSystemService FileSystem { get; }

    public SettingsService Settings { get; }

    public LogService Logger { get; }

    public JsonService Json { get; }

    public ProfileManager ProfileManager { get; }

    public ProfileService Profiles { get; }

    public WireGuardConfigService Config { get; }

    public DiagnosticsService Diagnostics { get; }

    public WireGuardService WireGuard { get; }

    public WireGuardImportService Import { get; }

    public ServiceManager()
    {
        FileSystem = new FileSystemService();
        FileSystem.Initialize();

        Settings = new SettingsService(FileSystem);
        Settings.Load();

        Logger = new LogService(FileSystem);

        Json = new JsonService();

        Profiles = new ProfileService(FileSystem, Json);

        ProfileManager = new ProfileManager(Profiles);

        Config = new WireGuardConfigService();

        Import = new WireGuardImportService();

        // Создаём WireGuard
        WireGuard = new WireGuardService();

        // Затем Diagnostics
        Diagnostics = new DiagnosticsService(WireGuard);
    }
}