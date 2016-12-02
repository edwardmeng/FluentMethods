using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static readonly MethodInfo GetFieldFromHandle = typeof(FieldInfo).GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle) });
    private static readonly MethodInfo GetFieldFromHandleGeneric = typeof(FieldInfo).GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle), typeof(RuntimeTypeHandle) });

    /// <summary>
    ///     Pushes the <see cref="FieldInfo" /> of the given field onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load the <see cref="FieldInfo" /> of</param>
    public static ILGenerator FieldOf(this ILGenerator il, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        il.Emit(OpCodes.Ldtoken, field);
        var declaringType = field.DeclaringType;
        if (declaringType != null && declaringType.IsGenericType)
        {
            il.Emit(OpCodes.Ldtoken, declaringType);
            return il.Call(GetFieldFromHandleGeneric);
        }
        return il.Call(GetFieldFromHandle);
    }
}