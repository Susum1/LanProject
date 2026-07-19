using System;
using System.Net.NetworkInformation;
using System.Security.Principal;
using MineLAN.Models;

namespace MineLAN.Services;

public class DiagnosticsService
{
    private readonly WireGuardService _wireGuard;

    public DiagnosticsService(WireGuardService wireGuard)
    {
        _wireGuard = wireGuard;
    }

    public SystemInfo GetSystemInfo()
    {
        return new SystemInfo
        {
            UserName = Environment.UserName,
            MachineName = Environment.MachineName,
            WindowsVersion = Environment.OSVersion.VersionString,
            HasInternet = NetworkInterface.GetIsNetworkAvailable(),
            IsAdministrator = IsAdministrator(),
            WireGuardInstalled = _wireGuard.IsInstalled(),
            WireGuardVersion = _wireGuard.GetVersion(),
            WireGuardPath = _wireGuard.GetExecutablePath()
        };
    }

    private bool IsAdministrator()
    {
        using WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new(identity);

        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }
}