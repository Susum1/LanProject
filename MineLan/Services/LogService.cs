using System.IO;
using System.Text;
using MineLAN.Models;

namespace MineLAN.Services;

public class LogService
{
    private readonly FileSystemService _fileSystem;

    public LogService(FileSystemService fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public void Write(string message)
    {
        string file = Path.Combine(
            _fileSystem.LogFolder,
            "latest.log");

        string line =
            $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";

        File.AppendAllText(file, line, Encoding.UTF8);
    }
}