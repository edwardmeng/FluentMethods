﻿using System;

public static partial class Extensions
{
    /// <summary>
    /// Inserts an element into the <paramref name="array"/> at the specified index.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="index">The zero-based index at which value should be inserted. </param>
    /// <param name="item">The element to insert. The element can be null for reference types.</param>
    /// <returns>An array with the inserted element.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is less than 0.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="index"/> is greater than the array element count.
    /// </exception>
    public static T[] Insert<T>(this T[] array, int index, T item)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (index < 0 || index > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        var copyArray = new T[array.Length + 1];
        Array.Copy(array, 0, copyArray, 0, index);
        copyArray[index] = item;
        Array.Copy(array, index, copyArray, index + 1, array.Length - index);
        return copyArray;
    }
}