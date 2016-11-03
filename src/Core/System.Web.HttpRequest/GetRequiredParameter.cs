using System.Web;

public static partial class Extensions
{
#if Net35
    private static object GetRequiredParameter(this HttpRequest request, string paraName)
    {
        object paraValue = request.GetParameter(paraName);
        if (paraValue == null || (paraValue is string && string.IsNullOrEmpty((string)paraValue)))
        {
            throw new ParameterMissedException(paraName);
        }
        return paraValue;
    }
    /// <summary>
    /// Gets the required value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="request">The request.</param>
    /// <param name="paraName">Name of the para.</param>
    /// <returns></returns>
    public static T GetRequiredParameter<T>(this HttpRequest request, string paraName)
    {
        return request.GetRequiredParameter(paraName).To<T>();
    }
#else
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
#endif
}