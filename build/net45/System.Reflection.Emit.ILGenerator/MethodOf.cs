using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static readonly MethodInfo GetMethodFromHandle = typeof(MethodBase).GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle) });
    private static readonly MethodInfo GetMethodFromHandleGeneric = typeof(MethodBase).GetMethod("GetMethodFromHandle", new[] { typeof(RuntimeMethodHandle), typeof(RuntimeTypeHandle) });

    /// <summary>
    ///     Pushes the <see cref="MethodBase" /> of the given method onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to load the <see cref="MethodBase" /> of</param>
    public static ILGenerator MethodOf(this ILGenerator il, MethodBase method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if(method == null)
            throw new ArgumentNullException(nameof(method));
        if (method is DynamicMethod)
            throw new InvalidOperationException();
        if (method.MemberType == MemberTypes.Constructor)
        {
            il.Emit(OpCodes.Ldtoken, (ConstructorInfo)method);
        }
        else
        {
            il.Emit(OpCodes.Ldtoken, (MethodInfo)method);
        }
        var declaringType = method.DeclaringType;
        if (declaringType != null && declaringType.IsGenericType)
        {
            il.Emit(OpCodes.Ldtoken, declaringType);
            return il.Call(GetMethodFromHandleGeneric);
        }
        return il.Call(GetMethodFromHandle);
    }
}