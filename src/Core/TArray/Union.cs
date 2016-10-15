using System;
using System.Collections.Generic;

public static partial class Extensions
{
    /// <summary>
    /// Produces the array union of two arrays by using the default equality comparer.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input arrays.</typeparam>
    /// <param name="first">An array whose distinct elements form the first set for the union.</param>
    /// <param name="second">An array whose distinct elements form the second set for the union.</param>
    /// <returns>An array that contains the elements from both input arrays, excluding duplicates.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
    /// </exception>
    public static T[] Union<T>(this T[] first, T[] second)
    {
        return first.Union(second, null);
    }

    /// <summary>
    /// Produces the array union of two arrays by using a specified <see cref="IEqualityComparer{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the elements of the input arrays.</typeparam>
    /// <param name="first">An array whose distinct elements form the first set for the union.</param>
    /// <param name="second">An array whose distinct elements form the second set for the union.</param>
    /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to compare values.</param>
    /// <returns>An array that contains the elements from both input arrays, excluding duplicates.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
    /// </exception>
    public static T[] Union<T>(this T[] first, T[] second, IEqualityComparer<T> comparer)
    {
        if (first == null)
        {
            throw new ArgumentNullException(nameof(first));
        }
        if (second == null)
        {
            throw new ArgumentNullException(nameof(second));
        }
        var set = new HashSet<T>(first, comparer);
        set.UnionWith(second);
        var result = new T[set.Count];
        set.CopyTo(result);
        return result;
    }
}