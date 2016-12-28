using System;
using System.Reflection.Emit;

public static partial class Extensions
{
    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType, Action<ILGenerator> filter)
    {
        if (il == null)
            throw new ArgumentNullException(nameof(il));
        if (filter == null)
        {
            il.BeginCatchBlock(exceptionType ?? typeof(object));
        }
        else
        {
            il.BeginExceptFilterBlock();
            if (exceptionType == null)
            {
                filter(il);
                il.BeginCatchBlock(null);
            }
            else
            {
                var exceptionLocal = il.DeclareLocal(exceptionType);
                Label endFilter = il.DefineLabel(), rightType = il.DefineLabel();
                il
                    .Isinst(exceptionType).Dup()
                    .BranchShortTo(rightType).IfTrue()
                    .Pop().Ldc(false)
                    .BranchTo(endFilter).Unconditionally();
                il.MarkLabel(rightType);
                il.StoreLocal(exceptionLocal);
                il.LoadLocal(exceptionLocal);
                filter(il);
                il.MarkLabel(endFilter);
                il.BeginCatchBlock(null);
                il.Pop().LoadLocal(exceptionLocal);
            }
        }
        return new ILGeneratorScope(il);
    }

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType, Action filter) => il.Catch(exceptionType, x => filter?.Invoke());

    /// <summary>
    /// Encapsulate the catch block of the exception handling.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, Type exceptionType) => il.Catch(exceptionType, (Action<ILGenerator>)null);

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <typeparam name="T">The type of the exception to be handled.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action<ILGenerator> filter) where T : Exception => il.Catch(typeof(T), filter);

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <typeparam name="T">The type of the exception to be handled.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch<T>(this ILGenerator il, Action filter) where T : Exception => il.Catch(typeof(T), filter);

    /// <summary>
    /// Encapsulate the catch block of the exception handling.
    /// </summary>
    /// <typeparam name="T">The type of the exception to be handled.</typeparam>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch<T>(this ILGenerator il) where T : Exception => il.Catch<T>((Action<ILGenerator>)null);

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, Action<ILGenerator> filter) => il.Catch((Type)null, filter);

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, Action filter) => il.Catch((Type)null, filter);

    /// <summary>
    /// Encapsulate the catch block of the exception handling.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il) => il.Catch((Action<ILGenerator>)null);

#if Net45 || NetCore
    /// <summary>
    /// Encapsulate the catch block of the exception handling.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType) => il.Catch(exceptionType?.AsType());

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType, Action filter) => il.Catch(exceptionType?.AsType(), filter);

    /// <summary>
    /// Encapsulate the catch block of the exception handling with an exception filter.
    /// </summary>
    /// <param name="il">The <see cref="ILGenerator" /> to emit instructions from</param>
    /// <param name="exceptionType">The type of the exception to be handled.</param>
    /// <param name="filter">The action to emit the exception filter.</param>
    /// <returns>The scope instance to encapsulate the catch block of exception handling.</returns>
    public static ILGeneratorScope Catch(this ILGenerator il, System.Reflection.TypeInfo exceptionType, Action<ILGenerator> filter) => il.Catch(exceptionType?.AsType(), filter);
#endif
}