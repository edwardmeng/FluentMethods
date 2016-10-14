using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync(0, async (sum, x, t) =>
        {
            checked
            {
                return sum + await selector(x, t);
            }
        }, token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<int?>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((int?) null, async (sum, x, t) =>
        {
            checked
            {
                return sum + await selector(x, t);
            }
        }, token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="int"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<int?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<int?>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((long)0, async (sum, x, t) =>
        {
            checked
            {
                return sum + await selector(x, t);
            }
        }, token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<long?>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((long?)null, async (sum, x, t) =>
        {
            checked
            {
                return sum + await selector(x, t);
            }
        }, token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="long"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<long?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<long?>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((float)0, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<float?>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((float?)null, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="float"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<float?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<float?>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((double)0, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<double?>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((double?)null, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="double"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<double?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<double?>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((decimal)0, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<decimal?>> selector, CancellationToken token)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));
        return source.AggregateAsync((decimal?)null, async (sum, x, t) => sum + await selector(x, t), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <param name="token">A <see cref="System.Threading.CancellationToken"/> to observe while waiting for the task to complete.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector, CancellationToken token)
    {
        return source.SumAsync(async (x, t) => await selector(x), token);
    }

    /// <summary>
    /// Asynchronously computes the sum of the sequence of nullable <see cref="decimal"/> values that are obtained by invoking a transform function on each element of the input sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
    /// <param name="source">A sequence of values that are used to calculate a sum.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the result of the sum of the projected values.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null" />.
    /// </exception>
    public static Task<decimal?> SumAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<decimal?>> selector)
    {
        return source.SumAsync(selector, CancellationToken.None);
    }

}