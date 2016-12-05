using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
#if NetCore
    private static readonly MethodInfo GetMethodFromHandle = typeof(MethodBase).GetTypeInfo().GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle) });
    private static readonly MethodInfo GetMethodFromHandleGeneric = typeof(MethodBase).GetTypeInfo().GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle) });
#else
    private static readonly MethodInfo GetMethodFromHandle = typeof(MethodBase).GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle) });
    private static readonly MethodInfo GetMethodFromHandleGeneric = typeof(MethodBase).GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle) });
#endif

    /// <summary>
    ///     Pushes the <see cref="MethodBase" /> of the given method onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to load the <see cref="MethodBase" /> of</param>
    public static ILGenerator MethodOf(this ILGenerator il, MethodBase method)
    {
        if(method == null)
            throw new ArgumentNullException(nameof(method));
#if !NetCore
        if (method is DynamicMethod)
            throw new InvalidOperationException();
#endif
        if (method.MemberType == MemberTypes.Constructor)
        {
            il.FluentEmit(OpCodes.Ldtoken, (ConstructorInfo)method);
        }
        else
        {
            il.FluentEmit(OpCodes.Ldtoken, (MethodInfo)method);
        }
#if NetCore
        var declaringType = method.DeclaringType?.GetTypeInfo();
#else
        var declaringType = method.DeclaringType;
#endif
        if (declaringType != null && declaringType.IsGenericType)
        {
            return il.FluentEmit(OpCodes.Ldtoken, declaringType).Call(GetMethodFromHandleGeneric);
        }
        return il.Call(GetMethodFromHandle);
    }
}