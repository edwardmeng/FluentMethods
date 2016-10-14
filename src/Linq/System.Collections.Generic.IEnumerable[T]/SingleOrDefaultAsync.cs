using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

public static partial class Extensions
{
    /// <summary>
    /// Asynchronously returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; 
    /// this method throws an exception if more than one element satisfies the condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. 
    /// The task result contains the single element of the input sequence that satisfies the condition, or default(TSource) if no such element is found.
    /// </returns>
    /// <remarks>
    /// Multiple active operations on the same context instance are not supported. 
    /// Use 'await' to ensure that any asynchronous operations have completed before calling another method on this context.
    /// </remarks>
    /// <exception cref="System.ArgumentNullException"><paramref name="source"/> or <paramref name="predicate"/> is null.</exception>
    /// <exception cref="System.InvalidOperationException">
    /// More than one element satisfies the condition in <paramref name="predicate"/>.
    /// </exception>
    [DebuggerStepperBoundary]
    public static async Task<TSource> SingleOrDefaultAsync<TSource>(this IEnumerable<TSource> source, Func<TSource, Task<bool>> predicate)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }
        if (predicate == null)
        {
            throw new ArgumentNullException(nameof(predicate));
        }
        TSource result = default(TSource);
        long count = 0;
        foreach (TSource element in source)
        {
            if (await predicate(element))
            {
                result = element;
                checked { count++; }
            }
        }
        switch (count)
        {
            case 0: return default(TSource);
            case 1: return result;
            default: throw new InvalidOperationException("Sequence contains more than one matching element");
        }
    }
}