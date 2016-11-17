using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Pushes a supplied value of type int32 onto the evaluation stack as an int32.
    /// </summary>
    public static ILGenerator Ldc_I4(this ILGenerator il, int value)
    {
        if (il == null)
        {
            throw new ArgumentNullException(nameof(il));
        }
        switch (value)
        {
            case -1:
                il.Emit(OpCodes.Ldc_I4_M1);
                return il;
            case 0:
                il.Emit(OpCodes.Ldc_I4_0);
                return il;
            case 1:
                il.Emit(OpCodes.Ldc_I4_1);
                return il;
            case 2:
                il.Emit(OpCodes.Ldc_I4_2);
                return il;
            case 3:
                il.Emit(OpCodes.Ldc_I4_3);
                return il;
            case 4:
                il.Emit(OpCodes.Ldc_I4_4);
                return il;
            case 5:
                il.Emit(OpCodes.Ldc_I4_5);
                return il;
            case 6:
                il.Emit(OpCodes.Ldc_I4_6);
                return il;
            case 7:
                il.Emit(OpCodes.Ldc_I4_7);
                return il;
            case 8:
                il.Emit(OpCodes.Ldc_I4_8);
                return il;
        }

        if (value > -129 && value < 128)
        {
            il.Emit(OpCodes.Ldc_I4_S, (sbyte)value);
        }
        else
        {
            il.Emit(OpCodes.Ldc_I4, value);
        }
        return il;
    }
}