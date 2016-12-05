using System;
using System.Reflection;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    ///     Creates a new object or instance of a value type, calling the given constructor (and popping the requisite
    ///     arguments from the evaluation stack) and pushing the reference or value (respectively) onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="constructor">The constructor to call</param>
    public static ILGenerator New(this ILGenerator il, ConstructorInfo constructor)
    {
        return il.FluentEmit(OpCodes.Newobj, constructor);
    }

    /// <summary>
    ///     Creates a new object or instance of a value type, calling the given constructor (and popping the requisite
    ///     arguments from the evaluation stack) and pushing the reference or value (respectively) onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of object/value type to create</param>
    public static ILGenerator New(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
#if NetCore
        var reflectingType = type.GetTypeInfo();
#else
        var reflectingType = type;
#endif
        if (reflectingType.IsValueType)
        {
            var loc = il.DeclareLocal(reflectingType);
            il.LoadLocalAddress(loc)
                .FluentEmit(OpCodes.Initobj, reflectingType)
                .LoadLocal(loc);
        }
        else
        {
            il.Emit(OpCodes.Newobj, reflectingType.GetConstructor(Type.EmptyTypes));
        }
        return il;
    }

    /// <summary>
    ///     Creates a new object or instance of a value type, calling the default constructor and pushing the reference or
    ///     value (respectively) onto the evaluation stack
    /// </summary>
    /// <typeparam name="T">The type of object/value type to create</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator New<T>(this ILGenerator il) where T : new()
    {
        return il.New(typeof(T));
    }

#if Net45 || NetCore
    
    /// <summary>
    ///     Creates a new object or instance of a value type, calling the given constructor (and popping the requisite
    ///     arguments from the evaluation stack) and pushing the reference or value (respectively) onto the evaluation stack
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of object/value type to create</param>
    public static ILGenerator New(this ILGenerator il, TypeInfo type)
    {
        return il.New(type?.AsType());
    }

#endif
}