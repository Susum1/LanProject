using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MineLAN.Services;

public class WireGuardService
{
    private readonly string[] _possiblePaths =
    {
        @"C:\Program Files\WireGuard\wireguard.exe",
        @"C:\Program Files (x86)\WireGuard\wireguard.exe"
    };

    public bool IsInstalled()
    {
        return GetExecutablePath() != null;
    }

    public string? GetExecutablePath()
    {
        foreach (string path in _possiblePaths)
        {
            if (File.Exists(path))
                return path;
        }

        return null;
    }

    public string GetVersion()
    {
        string? exe = GetExecutablePath();

        if (exe == null)
            return "Не установлен";

        try
        {
            ProcessStartInfo psi = new()
            {
                FileName = exe,
                Arguments = "/?",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using Process process = Process.Start(psi)!;

            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            process.WaitForExit();

            string text = string.IsNullOrWhiteSpace(output) ? error : output;

            string firstLine = text
                .Split('\n')
                .FirstOrDefault()?
                .Trim() ?? "Версия неизвестна";

            return firstLine;
        }
        catch
        {
            return "Не удалось определить";
        }
    }
}