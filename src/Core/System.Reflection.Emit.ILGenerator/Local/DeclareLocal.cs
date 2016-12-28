using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Declares a local variable of the specified type.
    /// </summary>
    /// <typeparam name="T">A <see cref="Type"/> object that represents the type of the local variable.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The declared local variable.</returns>
    public static LocalBuilder DeclareLocal<T>(this ILGenerator il)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.DeclareLocal(typeof(T));
    }

    /// <summary>
    /// Declares a local variable of the specified type, optionally pinning the object referred to by the variable.
    /// </summary>
    /// <typeparam name="T">A <see cref="Type"/> object that represents the type of the local variable.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="pinned"><c>true</c> to pin the object in memory; otherwise, <c>false</c>.</param>
    /// <returns>The declared local variable.</returns>
    public static LocalBuilder DeclareLocal<T>(this ILGenerator il, bool pinned)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        return il.DeclareLocal(typeof(T), pinned);
    }

#if NetCore || Net45

    /// <summary>
    /// Declares a local variable of the specified type.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">A <see cref="Type"/> object that represents the type of the local variable.</param>
    /// <returns>The declared local variable.</returns>

    public static LocalBuilder DeclareLocal(this ILGenerator il, System.Reflection.TypeInfo type)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return il.DeclareLocal(type.AsType());
    }

    /// <summary>
    /// Declares a local variable of the specified type, optionally pinning the object referred to by the variable.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="type">A <see cref="Type"/> object that represents the type of the local variable.</param>
    /// <param name="pinned"><c>true</c> to pin the object in memory; otherwise, <c>false</c>.</param>
    /// <returns>The declared local variable.</returns>

    public static LocalBuilder DeclareLocal(this ILGenerator il, System.Reflection.TypeInfo type, bool pinned)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (type == null)
            throw new ArgumentNullException(nameof(type));
        return il.DeclareLocal(type.AsType(), pinned);
    }

#endif
}