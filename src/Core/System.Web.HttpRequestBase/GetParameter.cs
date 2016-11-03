using System;
using System.Web;

public static partial class Extensions
{
    private static object GetParameter(this HttpRequestBase request, string paraName)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        if (string.IsNullOrWhiteSpace(paraName))
        {
            throw new ArgumentNullException(nameof(paraName));
        }
        return request.RequestContext.RouteData.Values[paraName] ?? request.QueryString[paraName] ?? request.Form[paraName];
    }

    /// <summary>
    /// Gets the request parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the parameter.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The request parameter value</returns>
    public static T GetParameter<T>(this HttpRequestBase request, string paraName, T defaultValue)
    {
        var paraValue = request.GetParameter(paraName);
        if (paraValue is T)
        {
            return (T)paraValue;
        }
        if (paraValue == null || (paraValue is string && string.IsNullOrEmpty((string)paraValue)))
        {
            return defaultValue;
        }
        if (typeof(T) == typeof(string))
        {
            return (T)(object)paraValue.ToString();
        }
        return (T)(paraValue.To(typeof(T)) ?? defaultValue);
    }

    /// <summary>
    /// Gets the request parameter value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the parameter.</param>
    /// <returns></returns>
    public static T GetParameter<T>(this HttpRequestBase request, string paraName)
    {
        return request.GetParameter(paraName, default(T));
    }
}