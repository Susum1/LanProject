using System.Diagnostics;
using System.IO;

namespace MineLAN.Services;

public class WireGuardImportService
{
    public bool Import(string confPath)
    {
        string exe =
            @"C:\Program Files\WireGuard\wireguard.exe";

        if (!File.Exists(exe))
            return false;

        Process.Start(new ProcessStartInfo
        {
            FileName = exe,
            Arguments = $"\"{confPath}\"",
            UseShellExecute = true
        });

        return true;
    }
}