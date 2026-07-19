using System.Diagnostics;

namespace MineLAN.Services;

public class WireGuardProcessService
{
    public string Execute(string fileName, string arguments)
    {
        ProcessStartInfo startInfo = new()
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new();

        process.StartInfo = startInfo;

        process.Start();

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();

        process.WaitForExit();

        return string.IsNullOrWhiteSpace(output)
            ? error
            : output;
    }
}