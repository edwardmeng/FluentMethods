using System.ComponentModel;
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
        object paraValue = request.GetRequiredParameter(paraName);
        if (paraValue is T)
        {
            return (T)paraValue;
        }
        if (typeof(T) == typeof(string))
        {
            return (T)(object)paraValue.ToString();
        }
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
        return (T)converter.ConvertFrom(paraValue);
    }
}