using System;

public static partial class Extensions
{
    /// <summary>
    /// Adds an element to the end of the <paramref name="array"/>.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="item">
    ///     The element to be added to the end of the array. 
    ///     The element can be null for reference types.
    /// </param>
    /// <returns>An array with the added element.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array"/> is <see langword="null"/>.
    /// </exception>
    public static T[] Add<T>(this T[] array, T item)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = item;
        return array;
    }
}