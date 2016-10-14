using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// Gets the required value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the para.</param>
    /// <returns></returns>
    public static T GetRequiredParameter<T>(this HttpRequest request, string paraName)
    {
        return new HttpRequestWrapper(request).GetRequiredParameter<T>(paraName);
    }
}