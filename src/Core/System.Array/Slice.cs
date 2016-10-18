using System;
using FluentMethods;

public static partial class Extensions
{
    /// <summary>
    /// Returns an <see cref="Array"/> which represents a subset of the elements in the source <see cref="Array"/>.
    /// </summary>
    /// <param name="sourceArray">The source array to be sliced.</param>
    /// <param name="startIndex">A 32-bit integer that represents the index in the <paramref name="sourceArray"/> at which slicing begins.</param>
    /// <param name="length">A 32-bit integer that represents the number of elements to slice.</param>
    /// <returns>An <see cref="Array"/> which represents a subset of the elements in the source <see cref="Array"/>.</returns>
    /// <exception cref="ArgumentNullException">The <paramref name="sourceArray"/> is <see langword="null"/></exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="startIndex"/> is less than the lower bound of the first dimension of sourceArray.
    /// </exception>
    /// <exception cref="ArgumentOutOfRangeException">
    ///     <paramref name="length"/> is less than zero.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="startIndex"/> and <paramref name="length"/> do not denote a valid range of elements in the <paramref name="sourceArray"/>. 
    /// </exception>
    public static Array Slice(this Array sourceArray, int startIndex, int length)
    {
        if (sourceArray == null)
        {
            throw new ArgumentNullException(nameof(sourceArray));
        }
        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(length));
        }
        if (startIndex + length > sourceArray.Length)
        {
            throw new ArgumentException(Strings.ArgumentOutOfRange_ArraySlice);
        }
        var copyArray = (Array)Activator.CreateInstance(sourceArray.GetType(), length);
        Array.Copy(sourceArray, startIndex, copyArray, 0, length);
        return copyArray;
    }
}