using System.Web;

public static partial class Extensions
{
    private static object GetRequiredParameter(this HttpRequestBase request, string paraName)
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
    public static T GetRequiredParameter<T>(this HttpRequestBase request, string paraName)
    {
        return request.GetRequiredParameter(paraName).ConvertTo<T>();
    }
}