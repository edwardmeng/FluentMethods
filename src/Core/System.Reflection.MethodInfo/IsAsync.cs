using System;
using System.Reflection;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Indicates whether the specified method is asynchronous.
    /// </summary>
    /// <param name="method">The method to detect.</param>
    /// <returns><c>true</c> if the specified method is asynchronous; <c>false</c> otherwise.</returns>
    public static bool IsAsync(this MethodInfo method)
    {
        if (method == null)
        {
            throw new ArgumentNullException(nameof(method));
        }
        var returnType = method.ReturnType;
#if NetCore
        return returnType == typeof(Task) || (returnType.GetTypeInfo().IsGenericType && returnType.GetTypeInfo().GetGenericTypeDefinition() == typeof(Task<>));
#else
        return returnType == typeof(Task) || (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>));
#endif
    }
}