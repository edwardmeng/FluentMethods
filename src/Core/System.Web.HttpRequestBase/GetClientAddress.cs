using System;
using System.Net;
using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// Returns the clients IP address.
    /// </summary>
    /// <returns>Prevents proxy issues by using the X_Forwarded_For header</returns>
    public static IPAddress GetClientAddress(this HttpRequestBase request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        var ipAddress = ParseClientAddress(request);

        if (ipAddress != null &&
            ipAddress.IsIn(IPAddress.Any, IPAddress.None, IPAddress.Loopback, IPAddress.Broadcast, IPAddress.IPv6Any, IPAddress.IPv6Loopback, IPAddress.IPv6None))
        {
            return null;
        }

        return ipAddress;
    }

    private static IPAddress ParseClientAddress(HttpRequestBase request)
    {
        var ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            var addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return IPAddress.Parse(addresses[0]);
            }
        }

        return string.IsNullOrEmpty(request.UserHostAddress) ? null : IPAddress.Parse(request.UserHostAddress);
    }
}