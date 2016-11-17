using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    public static ILGenerator Callvirt(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (method == null)
        {
            throw new ArgumentNullException(nameof(method));
        }
        il.Emit(OpCodes.Callvirt, method);
        return il;
    }
}