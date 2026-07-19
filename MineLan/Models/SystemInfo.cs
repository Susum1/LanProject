namespace MineLAN.Models;

public class SystemInfo
{
    public string UserName { get; set; } = "";

    public string MachineName { get; set; } = "";

    public string WindowsVersion { get; set; } = "";

    public bool HasInternet { get; set; }

    public bool IsAdministrator { get; set; }

    public bool WireGuardInstalled { get; set; }

    public string WireGuardVersion { get; set; } = "";

    public string? WireGuardPath { get; set; }
}