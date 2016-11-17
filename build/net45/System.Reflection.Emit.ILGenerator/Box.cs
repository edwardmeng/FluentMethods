using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Converts a value type to an object reference (type O).
    /// </summary>
    public static ILGenerator Box(this ILGenerator il, Type type)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        il.Emit(type.IsValueType ? OpCodes.Box : OpCodes.Castclass, type);
        return il;
    }
}