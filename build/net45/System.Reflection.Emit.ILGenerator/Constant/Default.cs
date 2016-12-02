using System;
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
            case TypeCode.DBNull:
            case TypeCode.String:
                il.LoadNull();
                break;
            case TypeCode.Boolean:
            case TypeCode.Char:
            case TypeCode.SByte:
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.UInt16:
            case TypeCode.Int32:
            case TypeCode.UInt32:
                il.Emit(OpCodes.Ldc_I4_0);
                break;
            case TypeCode.Int64:
            case TypeCode.UInt64:
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Conv_I8);
                break;
            case TypeCode.Single:
                il.Emit(OpCodes.Ldc_R4, 0f);
                break;
            case TypeCode.Double:
                il.Emit(OpCodes.Ldc_R8, 0.0);
                break;
            case TypeCode.Decimal:
                il.Emit(OpCodes.Ldc_I4_0);
                il.Emit(OpCodes.Newobj, typeof(decimal).GetConstructor(new[] { typeof(int) }));
                break;
            default:
                if (!type.IsValueType)
                {
                    il.Emit(OpCodes.Ldnull);
                }
                else
                {
                    LocalBuilder local = il.DeclareLocal(type);
                    il.Emit(OpCodes.Ldloca, local);
                    il.Emit(OpCodes.Initobj, type);
                    il.Emit(OpCodes.Ldloc, local);
                }
                break;
        }
        return il;
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
}