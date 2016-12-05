using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Loads the default value for the specified type.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to load default value.</param>
    public static ILGenerator Default(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        switch (Type.GetTypeCode(type))
        {
            case TypeCode.Empty:
#if !NetCore
            case TypeCode.DBNull:
#endif
            case TypeCode.String:
                return il.LoadNull();
            case TypeCode.Boolean:
            case TypeCode.Char:
            case TypeCode.SByte:
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
                return il.FluentEmit(OpCodes.Ldc_I4_0);
            case TypeCode.Int64:
            case TypeCode.UInt64:
                return il.FluentEmit(OpCodes.Ldc_I4_0).FluentEmit(OpCodes.Conv_I8);
            case TypeCode.Single:
                return il.FluentEmit(OpCodes.Ldc_R4, 0f);
            case TypeCode.Double:
                return il.FluentEmit(OpCodes.Ldc_R8, 0.0);
            case TypeCode.Decimal:
#if NetCore
                var constructor = typeof(decimal).GetTypeInfo().GetConstructor(new[] { typeof(int) });
#else
                var constructor = typeof(decimal).GetConstructor(new[] {typeof(int)});
#endif
                return il.FluentEmit(OpCodes.Ldc_I4_0).FluentEmit(OpCodes.Newobj, constructor);
            default:
#if NetCore
                var reflectingType = type.GetTypeInfo();
#else
                var reflectingType = type;
#endif

                if (!reflectingType.IsValueType)
                {
                    return il.FluentEmit(OpCodes.Ldnull);
                }
                var local = il.DeclareLocal(reflectingType);
                return il.FluentEmit(OpCodes.Ldloca, local)
                    .FluentEmit(OpCodes.Initobj, reflectingType)
                    .FluentEmit(OpCodes.Ldloc, local);
        }
    }

    /// <summary>
    ///     Loads the default value for the specified type.
    /// </summary>
    /// <typeparam name="T">The type to load default value.</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Default<T>(this ILGenerator il)
    {
        return il.Default(typeof(T));
    }

#if Net45 || NetCore
    
    /// <summary>
    ///     Loads the default value for the specified type.
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type to load default value.</param>
    public static ILGenerator Default(this ILGenerator il, TypeInfo type) => il.Default(type?.AsType());

#endif
}