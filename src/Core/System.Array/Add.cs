using System;
using FluentMethods;

public static partial class Extensions
{
    /// <summary>
    /// Adds an element to the end of the <paramref name="array"/>.
    /// </summary>
    /// <param name="array">The original array.</param>
    /// <param name="item">
    ///     The element to be added to the end of the array. 
    ///     The element can be null for reference types.
    /// </param>
    /// <returns>An array with the added element.</returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="array"/> is <see langword="null"/>.
    /// </exception>
    public static Array Add(this Array array, object item)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (array.Rank != 1)
            throw new RankException(Strings.Rank_MultiDimNotSupported);
        var newArray =
            (Array)Activator.CreateInstance(array.GetType(), array.Length + 1);
        Array.Copy(array, 0, newArray, 0, array.Length);
        newArray.SetValue(item, newArray.Length - 1);
        return newArray;
    }
}