namespace MineLAN.Models;

public class WireGuardProfile
{
    public string Name { get; set; } = "";

    public string PrivateKey { get; set; } = "";

    public string PublicKey { get; set; } = "";

    public string Address { get; set; } = "";

    public string DNS { get; set; } = "1.1.1.1";

    public string Endpoint { get; set; } = "";

    public string AllowedIPs { get; set; } = "0.0.0.0/0";

    public int ListenPort { get; set; } = 51820;

    public string PresharedKey { get; set; } = "";
}