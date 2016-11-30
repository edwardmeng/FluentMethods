using System;
using System.Reflection;
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

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, Label[] labels)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (labels == null)
            throw new ArgumentNullException(nameof(labels));
        il.Emit(opcode, labels);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, LocalBuilder local)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (local == null)
            throw new ArgumentNullException(nameof(local));
        il.Emit(opcode, local);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, byte value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(opcode, value);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, int value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(opcode, value);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, string value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (value == null)
            throw new ArgumentNullException(nameof(value));
        il.Emit(opcode, value);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, FieldInfo field)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (field == null)
            throw new ArgumentNullException(nameof(field));
        il.Emit(opcode, field);
        return il;
    }
}