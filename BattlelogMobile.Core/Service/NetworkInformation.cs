using System.Linq;
using Microsoft.Phone.Net.NetworkInformation;

namespace BattlelogMobile.Core.Service
{
    public static class NetworkInformation
    {
        public static string Current()
        {
            var connected = (new NetworkInterfaceList()).Where(network => network.InterfaceState == ConnectState.Connected).ToList();
            var types =  connected.Select(network => network.InterfaceSubtype).ToList();

            // WiFi
            if (types.Any(n => n == NetworkInterfaceSubType.WiFi))
                return "WiFi";

            // Cellular networks
            if (types.Any(n => n == NetworkInterfaceSubType.Cellular_HSPA))
                return "Cellular 3.5G";
            if (types.Any(n => n == NetworkInterfaceSubType.Cellular_3G ||
                               n == NetworkInterfaceSubType.Cellular_EVDO ||
                               n == NetworkInterfaceSubType.Cellular_EVDV))
                return "Cellular 3G";
            if (types.Any(n => n == NetworkInterfaceSubType.Cellular_1XRTT ||
                               n == NetworkInterfaceSubType.Cellular_EDGE ||
                               n == NetworkInterfaceSubType.Cellular_GPRS))
                return "Cellular 2.5G";

            // USB or equivalent (does WP actually use this, I do not know...)
            if (types.Any(n => n == NetworkInterfaceSubType.Desktop_PassThru))
                return "Desktop passthru";

            // For network unavailable and unknown cases, just return blank
            return string.Empty;
        }
    }
}
