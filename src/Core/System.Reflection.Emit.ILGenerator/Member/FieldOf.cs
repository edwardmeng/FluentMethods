using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
#if NetCore
    private static readonly MethodInfo GetFieldFromHandle = typeof(FieldInfo).GetTypeInfo().GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle) });
    private static readonly MethodInfo GetFieldFromHandleGeneric = typeof(FieldInfo).GetTypeInfo().GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle), typeof(RuntimeTypeHandle) });
#else
    private static readonly MethodInfo GetFieldFromHandle = typeof(FieldInfo).GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle) });
    private static readonly MethodInfo GetFieldFromHandleGeneric = typeof(FieldInfo).GetMethod("GetFieldFromHandle", new[] { typeof(RuntimeFieldHandle), typeof(RuntimeTypeHandle) });
#endif

    /// <summary>
    ///     Pushes the <see cref="FieldInfo" /> of the given field onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="field">The field to load the <see cref="FieldInfo" /> of</param>
    public static ILGenerator FieldOf(this ILGenerator il, FieldInfo field)
    {
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        il.FluentEmit(OpCodes.Ldtoken, field);
#if NetCore
        var declaringType = field.DeclaringType?.GetTypeInfo();
#else
        var declaringType = field.DeclaringType;
#endif
        if (declaringType != null && declaringType.IsGenericType)
        {
            return il.FluentEmit(OpCodes.Ldtoken, declaringType).Call(GetFieldFromHandleGeneric);
        }
        return il.Call(GetFieldFromHandle);
    }
}