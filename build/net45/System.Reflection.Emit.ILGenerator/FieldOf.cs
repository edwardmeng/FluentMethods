using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static readonly MethodInfo GetFieldFromHandle = typeof(FieldInfo).GetMethod("GetFieldFromHandle", new[] {typeof(RuntimeFieldHandle)});

    /// <summary>
    ///     Pushes the <see cref="FieldInfo" /> of the given field onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load the <see cref="FieldInfo" /> of</param>
    public static ILGenerator FieldInfoFor(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(OpCodes.Ldtoken, field);
        return il.Call(GetFieldFromHandle);
    }
}