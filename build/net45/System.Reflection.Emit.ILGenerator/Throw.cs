using System;
using System.Reflection;
using System.Reflection.Emit;

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
        il.Emit(OpCodes.Throw);
        return il;
    }

    /// <summary>
    ///     Throws an exception of the given type, using the default constructor
    /// </summary>
    /// <typeparam name="T">The type of the exception to throw</typeparam>
    /// <param name="il">The <see cref="T:System.Reflection.Emit.ILGenerator" /> to emit instructions from</param>
    public static ILGenerator Throw<T>(this ILGenerator il) where T : Exception, new()
    {
        il.ThrowException(typeof(T));
        return il;
    }

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
        var constructor = typeof(T).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, StringTypeArray, null);

        if (constructor == null)
            throw new InvalidOperationException("Exception type " + typeof(T).Name + " does not have a public constructor taking only a string");

        return il.LoadString(message).NewObject(constructor).Throw();
    }
}