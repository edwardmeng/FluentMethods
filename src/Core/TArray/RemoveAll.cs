using System;

public static partial class Extensions
{
    /// <summary>
    /// Removes all the elements that match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T">The array element type.</typeparam>
    /// <param name="array">The original array.</param>
    /// <param name="match">The <see cref="Predicate{T}"/> delegate that defines the conditions of the elements to remove.</param>
    /// <returns>An array without the matched elements.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="match"/> is null.</exception>
    public static T[] RemoveAll<T>(this T[] array, Predicate<T> match)
    {
        if (match == null) throw new ArgumentNullException(nameof(match));
        int size = array.Length;
        var destArray = new T[size];
        var destIndex = 0;
        for (int i = 0; i < size; i++)
        {
            var itemValue = array[i];
            if (!match(itemValue))
            {
                destArray[destIndex] = itemValue;
                destIndex++;
            }
        }
        Array.Resize(ref destArray, destIndex);
        return destArray;
    }
}