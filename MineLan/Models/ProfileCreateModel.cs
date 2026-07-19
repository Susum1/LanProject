namespace MineLAN.Models;

public class ProfileCreateModel
{
    public string Name { get; set; } = "";

    public string Address { get; set; } = "";

    public string Endpoint { get; set; } = "";

    public string DNS { get; set; } = "1.1.1.1";
}