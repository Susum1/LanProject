namespace MineLAN.Services;

public class ApplicationController
{
    public string ApplicationName => "MineLAN";

    public string Version => "0.1.0 Alpha";

    public string Status => "Ready";

    public ServiceManager Services { get; }

    public ApplicationController()
    {
        Services = new ServiceManager();
    }

    public void Initialize()
    {
        Services.Logger.Write("MineLAN started.");
    }
}