using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator Call(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (method == null)
        {
            throw new ArgumentNullException(nameof(method));
        }
        il.Emit(OpCodes.Call, method);
        return il;
    }

    /// <summary>
    /// Calls the method indicated by the passed method descriptor.
    /// </summary>
    public static ILGenerator Call(this ILGenerator il, MethodBase method)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (method == null)
        {
            throw new ArgumentNullException(nameof(method));
        }
        if (method.IsFinal || !method.IsVirtual)
        {
            if (method.MemberType == MemberTypes.Constructor)
            {
                il.Emit(OpCodes.Call, (ConstructorInfo)method);
            }
            else
            {
                il.Emit(OpCodes.Call, (MethodInfo)method);
            }
        }
        else
        {
            if (method.MemberType == MemberTypes.Constructor)
            {
                il.Emit(OpCodes.Callvirt, (ConstructorInfo)method);
            }
            else
            {
                il.Emit(OpCodes.Callvirt, (MethodInfo)method);
            }
        }
        return il;
    }
}