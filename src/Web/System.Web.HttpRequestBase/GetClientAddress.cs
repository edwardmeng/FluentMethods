using System;
using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// Returns the clients IP address.
    /// </summary>
    /// <returns>Prevents proxy issues by using the X_Forwarded_For header</returns>
    public static string GetClientAddress(this HttpRequestBase request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        var ipAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipAddress))
        {
            var addresses = ipAddress.Split(',');
            if (addresses.Length != 0)
            {
                return addresses[0];
            }
        }

        return request.ServerVariables["REMOTE_ADDR"];
    }
}