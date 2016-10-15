using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public static partial class Extensions
{
    /// <summary>
    ///     Returns a read-only wrapper for the specified <see cref="IDictionary{TKey, TValue}"/>.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to act on.</param>
    /// <returns>A read-only <see cref="IReadOnlyDictionary{TKey, TValue}"/> wrapper for the specified <see cref="IDictionary{TKey, TValue}"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dictionary"/> is null.</exception>
    public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
        {
            throw new ArgumentNullException(nameof(dictionary));
        }
        return new ReadOnlyDictionary<TKey, TValue>(dictionary);
    }
}