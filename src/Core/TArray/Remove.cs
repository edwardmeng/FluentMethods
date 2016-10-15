using System;

public static partial class Extensions
{
    /// <summary>
    /// Removes the first occurrence of a specific object from the <paramref name="array"/>.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="item">
    ///     The element to remove from the <paramref name="array"/>. 
    ///     The value can be null for reference types.
    /// </param>
    /// <returns>An array without the specified element.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array"/> is <see langword="null"/>.
    /// </exception>
    public static T[] Remove<T>(this T[] array, T item)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        var index = Array.IndexOf(array, item);
        return index != -1 ? array.RemoveAt(index) : array;
    }
}