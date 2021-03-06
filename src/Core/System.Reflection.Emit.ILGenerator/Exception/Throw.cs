﻿using System;
using System.Reflection;
using System.Reflection.Emit;
using FluentMethods;

public static partial class Extensions
{
    private static readonly Type[] StringTypeArray = {typeof(string)};

    /// <summary>
    ///     Pops a reference to an exception off the evaluation stack and throws it
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Throw(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.FluentEmit(OpCodes.Throw);
    }

    /// <summary>
    ///     Pops a reference to an exception off the evaluation stack and throws it
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the exception to throw</param>
    public static ILGenerator Throw(this ILGenerator il, Type type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        il.ThrowException(type);
        return il;
    }

    /// <summary>
    ///     Throws an exception of the given type, using the default constructor
    /// </summary>
    /// <typeparam name="T">The type of the exception to throw</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Throw<T>(this ILGenerator il) where T : Exception, new() => il.Throw(typeof(T));

    /// <summary>
    ///     Throws an exception of the given type with the given message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="message">The message to give the exception</param>
    /// <exception cref="InvalidOperationException">
    ///     Exception type <typeparamref name="T" /> does not have a public constructor
    ///     taking only a string
    /// </exception>
    public static ILGenerator Throw<T>(this ILGenerator il, string message) where T : Exception
    {
#if NetCore
        var constructor = typeof(T).GetTypeInfo().GetConstructor(StringTypeArray);
        if (!constructor.IsPublic) constructor = null;
#else
        var constructor = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, StringTypeArray, null);
#endif
        if (constructor == null)
            throw new InvalidOperationException(string.Format(Strings.NoExceptionConstructor, typeof(T).FullName));

        return il.LoadString(message).New(constructor).Throw();
    }

#if Net45 || NetCore
    /// <summary>
    ///     Pops a reference to an exception off the evaluation stack and throws it
    /// </summary>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    /// <param name="type">The type of the exception to throw</param>
    public static ILGenerator Throw(this ILGenerator il, TypeInfo type) => il.Throw(type?.AsType());
#endif
}