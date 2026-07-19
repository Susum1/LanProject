namespace MineLAN.Services;

public class ApplicationController
{
    public string ApplicationName => "MineLAN";

    public string Version => "0.0.4 Foundation";

    public string Status => "Ready";

    public ServiceManager Services { get; }

    public ApplicationController()
    {
        Services = new ServiceManager();

        Services.Logger.Write("MineLAN started.");
    }
}