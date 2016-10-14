using System.Web;

public static partial class Extensions
{
    /// <summary>
    /// Gets the request parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the parameter.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The request parameter value</returns>
    public static T GetParameter<T>(this HttpRequest request, string paraName, T defaultValue)
    {
        return new HttpRequestWrapper(request).GetParameter(paraName,defaultValue);
    }

    /// <summary>
    /// Gets the request parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the parameter.</param>
    /// <returns></returns>
    public static T GetParameter<T>(this HttpRequest request, string paraName)
    {
        return request.GetParameter(paraName, default(T));
    }
}