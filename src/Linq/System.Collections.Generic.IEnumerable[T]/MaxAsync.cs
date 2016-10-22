using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<int> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        var maxValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value > maxValue) maxValue = value;
            }
            else
            {
                maxValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return maxValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<int> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<int> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<int?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        int? maxValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (maxValue == null || value > maxValue) maxValue = value;
            token.ThrowIfCancellationRequested();
        }
        return maxValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<int?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<int?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<long> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long maxValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value > maxValue) maxValue = value;
            }
            else
            {
                maxValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return maxValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<long> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<long> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<long?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long? maxValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (maxValue == null || value > maxValue) maxValue = value;
            token.ThrowIfCancellationRequested();
        }
        return maxValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<long?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<long?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double maxValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value > maxValue) maxValue = value;
            }
            else
            {
                maxValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return maxValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double? maxValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (maxValue == null || value > maxValue) maxValue = value;
            token.ThrowIfCancellationRequested();
        }
        return maxValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<float> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        float maxValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value > maxValue) maxValue = value;
            }
            else
            {
                maxValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return maxValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<float?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        float? maxValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (maxValue == null || value > maxValue) maxValue = value;
            token.ThrowIfCancellationRequested();
        }
        return maxValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<decimal> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal maxValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value > maxValue) maxValue = value;
            }
            else
            {
                maxValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return maxValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<decimal?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal? maxValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (maxValue == null || value > maxValue) maxValue = value;
            token.ThrowIfCancellationRequested();
        }
        return maxValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the maximum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal?> MaxAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the maximum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<TResult> MaxAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<TResult>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        Comparer<TResult> comparer = Comparer<TResult>.Default;
        var maxValue = default(TResult);
        if (maxValue == null)
        {
            foreach (var x in source)
            {
                var value = await selector(x, token);
                if (value != null && (maxValue == null || comparer.Compare(value, maxValue) > 0))
                    maxValue = value;
                token.ThrowIfCancellationRequested();
            }
            return maxValue;
        }
        else
        {
            bool hasValue = false;
            foreach (var x in source)
            {
                var value = await selector(x, token);
                if (hasValue)
                {
                    if (comparer.Compare(value, maxValue) > 0)
                        maxValue = value;
                }
                else
                {
                    maxValue = value;
                    hasValue = true;
                }
                token.ThrowIfCancellationRequested();
            }
            if (hasValue) return maxValue;
            throw new InvalidOperationException(Strings.NoElements);
        }
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the maximum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TResult> MaxAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, CancellationToken token)
    {
        return source.MaxAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the maximum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the maximum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the maximum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<TResult> MaxAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
    {
        return source.MaxAsync(selector, CancellationToken.None);
    }
}