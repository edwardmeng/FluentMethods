using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(opcode);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(opcode, type);
        return il;
    }
}