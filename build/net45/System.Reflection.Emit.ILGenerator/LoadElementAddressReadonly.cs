using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the address of the element at that array index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    public static ILGenerator LoadElementAddressReadonly(this ILGenerator il, Type type)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }
        il.Emit(OpCodes.Readonly);
        il.Emit(OpCodes.Ldelema, type);
        return il;
    }

    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the address of the element at the given index, with restrictions on its use by other code
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of elements in the array</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator LoadElementAddressReadonly(this ILGenerator il, Type type, uint index)
    {
        return il.LoadConst(index)
                        .LoadElementAddressReadonly(type);
    }

    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the address of the element at that array index, with restrictions on its use by other code
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator LoadElementAddressReadonly<T>(this ILGenerator il) => il.LoadElementAddressReadonly(typeof(T));

    /// <summary>
    /// Pops an array reference (containing elements of the given type) and an index off the evaluation stack and pushes the address of the element at the given index, with restrictions on its use by other code
    /// </summary>
    /// <typeparam name="T">The type of elements in the array</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="index">The index of the element to load the address of</param>
    public static ILGenerator LoadElementAddressReadonly<T>(this ILGenerator il, uint index)
    {
        return il.LoadConst(index)
                        .LoadElementAddressReadonly(typeof(T));
    }
}