using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static readonly MethodInfo GetMethodFromHandle = typeof(MethodBase).GetMethod("GetMethodFromHandle", new[] {typeof(RuntimeMethodHandle)});

    /// <summary>
    ///     Pushes the <see cref="MethodInfo" /> of the given method onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="method">The method to load the <see cref="MethodInfo" /> of</param>
    public static ILGenerator MethodInfoFor(this ILGenerator il, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Ldtoken, method);
        return il.Call(GetMethodFromHandle);
    }
}