using MineLAN.Models;

namespace MineLAN.Services;

public class ProfileFactory
{
    public WireGuardProfile Create(ProfileCreateModel model)
    {
        return new WireGuardProfile
        {
            Name = model.Name,

            Address = model.Address,

            Endpoint = model.Endpoint,

            DNS = model.DNS,

            PrivateKey = "",

            PublicKey = "",

            PresharedKey = "",

            AllowedIPs = "0.0.0.0/0"
        };
    }
}