using System.Text;
using MineLAN.Models;

namespace MineLAN.Services;

public class WireGuardConfigService
{
    public string Build(WireGuardProfile profile)
    {
        StringBuilder sb = new();

        sb.AppendLine("[Interface]");
        sb.AppendLine($"PrivateKey = {profile.PrivateKey}");
        sb.AppendLine($"Address = {profile.Address}");
        sb.AppendLine($"DNS = {profile.DNS}");
        sb.AppendLine();

        sb.AppendLine("[Peer]");
        sb.AppendLine($"PublicKey = {profile.PublicKey}");

        if (!string.IsNullOrWhiteSpace(profile.PresharedKey))
            sb.AppendLine($"PresharedKey = {profile.PresharedKey}");

        sb.AppendLine($"Endpoint = {profile.Endpoint}");
        sb.AppendLine($"AllowedIPs = {profile.AllowedIPs}");

        return sb.ToString();
    }
}