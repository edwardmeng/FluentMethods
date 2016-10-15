using System;

public static partial class Extensions
{
    /// <summary>
    /// Removes the element at the specified index of the <paramref name="array"/>.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="index">The zero-based index of the element to remove.</param>
    /// <returns>An array without the specified element.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than 0.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is equal or greater than the array element count.
    /// </exception>
    public static T[] RemoveAt<T>(this T[] array, int index)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (index < 0 || index >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var copyArray = new T[array.Length - 1];
        Array.Copy(array, 0, copyArray, 0, index);
        Array.Copy(array, index + 1, copyArray, index, copyArray.Length - index);
        return copyArray;
    }
}