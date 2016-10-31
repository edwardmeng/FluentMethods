using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                sum += await selector(v, token);
                count++;
                token.ThrowIfCancellationRequested();
            }
        }
        if (count > 0) return (double)sum / count;
        throw new InvalidOperationException(FluentMethods.Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                var value = await selector(v, token);
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
                token.ThrowIfCancellationRequested();
            }
        }
        return count > 0 ? (double?)((double)sum / count) : null;
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                sum += await selector(v, token);
                count++;
                token.ThrowIfCancellationRequested();
            }
        }
        if (count > 0) return (double)sum / count;
        throw new InvalidOperationException(FluentMethods.Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        long sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                var value = await selector(v, token);
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
                token.ThrowIfCancellationRequested();
            }
        }
        return count > 0 ? (double?)((double)sum / count) : null;
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<float> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                sum += await selector(v, token);
                count++;
                token.ThrowIfCancellationRequested();
            }
        }
        if (count > 0) return (float)(sum / count);
        throw new InvalidOperationException(FluentMethods.Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<float?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                var value = await selector(v, token);
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
                token.ThrowIfCancellationRequested();
            }
        }
        return count > 0 ? (float?)(float)(sum / count) : null;
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<float?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                sum += await selector(v, token);
                count++;
                token.ThrowIfCancellationRequested();
            }
        }
        if (count > 0) return sum / count;
        throw new InvalidOperationException(FluentMethods.Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        double sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                var value = await selector(v, token);
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
                token.ThrowIfCancellationRequested();
            }
        }
        return count > 0 ? (double?)(sum / count) : null;
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<double?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<decimal> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                sum += await selector(v, token);
                count++;
                token.ThrowIfCancellationRequested();
            }
        }
        if (count > 0) return sum / count;
        throw new InvalidOperationException(FluentMethods.Strings.NoElements);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static async Task<decimal?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal?>> selector, CancellationToken token)
    {
        token.ThrowIfCancellationRequested();
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        decimal sum = 0;
        long count = 0;
        checked
        {
            foreach (var v in source)
            {
                var value = await selector(v, token);
                if (value.HasValue)
                {
                    sum += value.Value;
                    count++;
                }
                token.ThrowIfCancellationRequested();
            }
        }
        return count > 0 ? (decimal?)(sum / count) : null;
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector, CancellationToken token)
    {
        return source.AverageAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the average of a sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values to calculate the average of.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the average of the sequence of values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    [DebuggerStepThrough]
    public static Task<decimal?> AverageAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector)
    {
        return source.AverageAsync(selector, CancellationToken.None);
    }

}