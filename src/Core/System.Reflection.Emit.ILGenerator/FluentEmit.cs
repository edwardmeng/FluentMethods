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

#if Net45 || NetCore
    
    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, TypeInfo type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        il.Emit(opcode, type.AsType());
        return il;
    }

#endif

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, Label label)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (label == null)
            throw new ArgumentNullException(nameof(label));
        il.Emit(opcode, label);
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

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, float value)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.Emit(opcode, value);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, double value)
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

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, ConstructorInfo constructor)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (constructor == null)
            throw new ArgumentNullException(nameof(constructor));
        il.Emit(opcode, constructor);
        return il;
    }

    private static ILGenerator FluentEmit(this ILGenerator il, OpCode opcode, MethodInfo method)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (method == null)
            throw new ArgumentNullException(nameof(method));
        il.Emit(opcode, method);
        return il;
    }
}