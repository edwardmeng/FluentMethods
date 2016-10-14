using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentMethods.Linq;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<int> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        var minValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value < minValue) minValue = value;
            }
            else
            {
                minValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return minValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<int?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        int? minValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (minValue == null || value < minValue) minValue = value;
            token.ThrowIfCancellationRequested();
        }
        return minValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="int"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<long> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long minValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value < minValue) minValue = value;
            }
            else
            {
                minValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return minValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<long?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long? minValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (minValue == null || value < minValue) minValue = value;
            token.ThrowIfCancellationRequested();
        }
        return minValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="long"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<double> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double minValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value < minValue || double.IsNaN(value)) minValue = value;
            }
            else
            {
                minValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return minValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<double?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double? minValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (value == null) continue;
            if (minValue == null || value < minValue || double.IsNaN((double)value)) minValue = value;
            token.ThrowIfCancellationRequested();
        }
        return minValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="double"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<float> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        float minValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                // Normally NaN < anything is false, as is anything < NaN
                // However, this leads to some irksome outcomes in Min and Max.
                // If we use those semantics then Min(NaN, 5.0) is NaN, but
                // Min(5.0, NaN) is 5.0!  To fix this, we impose a total
                // ordering where NaN is smaller than every value, including
                // negative infinity.
                if (value < minValue || float.IsNaN(value)) minValue = value;
            }
            else
            {
                minValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return minValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<float?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        float? minValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (value == null) continue;
            if (minValue == null || value < minValue || float.IsNaN((float)value)) minValue = value;
            token.ThrowIfCancellationRequested();
        }
        return minValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="float"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<decimal> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal minValue = 0;
        bool hasValue = false;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (hasValue)
            {
                if (value < minValue) minValue = value;
            }
            else
            {
                minValue = value;
                hasValue = true;
            }
            token.ThrowIfCancellationRequested();
        }
        if (hasValue) return minValue;
        throw new InvalidOperationException(Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<decimal?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal? minValue = null;
        foreach (var x in source)
        {
            var value = await selector(x, token);
            if (minValue == null || value < minValue) minValue = value;
            token.ThrowIfCancellationRequested();
        }
        return minValue;
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a sequence and returns the minimum nullable <see cref="decimal"/> value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal?> MinAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the minimum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static async Task<TResult> MinAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<TResult>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        Comparer<TResult> comparer = Comparer<TResult>.Default;
        var minValue = default(TResult);
        if (minValue == null)
        {
            foreach (var x in source)
            {
                var value = await selector(x, token);
                if (value != null && (minValue == null || comparer.Compare(value, minValue) < 0))
                    minValue = value;
                token.ThrowIfCancellationRequested();
            }
            return minValue;
        }
        else
        {
            bool hasValue = false;
            foreach (var x in source)
            {
                var value = await selector(x, token);
                if (hasValue)
                {
                    if (comparer.Compare(value, minValue) < 0)
                        minValue = value;
                }
                else
                {
                    minValue = value;
                    hasValue = true;
                }
                token.ThrowIfCancellationRequested();
            }
            if (hasValue) return minValue;
            throw new InvalidOperationException(Strings.NoElements);
        }
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the minimum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<TResult> MinAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector, CancellationToken token)
    {
        return source.MinAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously invokes a transform function on each element of a generic sequence and returns the minimum resulting value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="source">A sequence of values to determine the minimum value of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the minimum value in the sequence.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<TResult> MinAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
    {
        return source.MinAsync(selector, CancellationToken.None);
    }
}