namespace MineLAN.Models;

public class AppSettings
{
    public string Username { get; set; } = Environment.UserName;

    public string ServerAddress { get; set; } = "";

    public bool AutoConnect { get; set; }

    public bool StartWithWindows { get; set; }
}