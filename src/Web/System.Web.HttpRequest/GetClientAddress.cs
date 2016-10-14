using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// Returns the clients IP address.
    /// </summary>
    /// <returns>Prevents proxy issues by using the X_Forwarded_For header</returns>
    public static string GetClientAddress(this HttpRequest request)
    {
       return new HttpRequestWrapper(request).GetClientAddress();
    }
}