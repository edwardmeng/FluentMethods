using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously applies an accumulator function over a sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the final accumulated value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="func"/> is <see langword="null" />.
    /// </exception>
    /// <exception cref="InvalidOperationException"><paramref name="source"/> contains no elements.</exception>
    [DebuggerStepperBoundary]
    public static async Task<TSource> AggregateAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, Task<TSource>> func)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (func == null) throw new ArgumentNullException(nameof(func));
        using (var e = source.GetEnumerator())
        {
            if (!e.MoveNext()) throw new InvalidOperationException("Sequence contains no elements");
            var result = e.Current;
            while (e.MoveNext()) result = await func(result, e.Current);
            return result;
        }
    }

    /// <summary>
    /// Asynchronously applies an accumulator function over a sequence. 
    /// The specified seed value is used as the initial accumulator value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the final accumulated value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="func"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task<TAccumulate> AggregateAsync<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, Task<TAccumulate>> func)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (func == null) throw new ArgumentNullException(nameof(func));
        var result = seed;
        await source.ForEachAsync(async element => result = await func(result, element));
        return result;
    }

    /// <summary>
    /// Applies an accumulator function over a sequence. 
    /// The specified seed value is used as the initial accumulator value, 
    /// and the specified function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the transformed final accumulator value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/>, <paramref name="func"/> or <paramref name="resultSelector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, Task<TAccumulate>> func, Func<TAccumulate, TResult> resultSelector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (func == null) throw new ArgumentNullException(nameof(func));
        if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
        var result = seed;
        await source.ForEachAsync(async element => result = await func(result, element));
        return resultSelector(result);
    }

    /// <summary>
    /// Applies an accumulator function over a sequence. 
    /// The specified seed value is used as the initial accumulator value, 
    /// and the specified function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the transformed final accumulator value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/>, <paramref name="func"/> or <paramref name="resultSelector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, Task<TResult>> resultSelector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (func == null) throw new ArgumentNullException(nameof(func));
        if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
        var result = seed;
        source.ForEach(element => result = func(result, element));
        return await resultSelector(result);
    }

    /// <summary>
    /// Applies an accumulator function over a sequence. 
    /// The specified seed value is used as the initial accumulator value, 
    /// and the specified function is used to select the result value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to aggregate over.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the transformed final accumulator value.</returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException">
    /// <paramref name="source"/>, <paramref name="func"/> or <paramref name="resultSelector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task<TResult> AggregateAsync<TSource, TAccumulate, TResult>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, Task<TAccumulate>> func, Func<TAccumulate, Task<TResult>> resultSelector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (func == null) throw new ArgumentNullException(nameof(func));
        if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
        var result = seed;
        await source.ForEachAsync(async element => result = await func(result, element));
        return await resultSelector(result);
    }
}