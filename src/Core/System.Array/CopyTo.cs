﻿using System;

public static partial class Extensions
{
    /// <summary>
    ///     Copies a range of elements from an  starting at the first element and pastes them into another  starting at
    ///     the first element. The length is specified as a 32-bit integer.
    /// </summary>
    /// <param name="sourceArray">The  that contains the data to copy.</param>
    /// <param name="destinationArray">The  that receives the data.</param>
    /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
    public static void CopyTo(this Array sourceArray, Array destinationArray, int length)
    {
        Array.Copy(sourceArray, destinationArray, length);
    }

    /// <summary>
    ///     Copies a range of elements from an  starting at the specified source index and pastes them to another
    ///     starting at the specified destination index. The length and the indexes are specified as 32-bit integers.
    /// </summary>
    /// <param name="sourceArray">The  that contains the data to copy.</param>
    /// <param name="sourceIndex">A 32-bit integer that represents the index in the  at which copying begins.</param>
    /// <param name="destinationArray">The  that receives the data.</param>
    /// <param name="destinationIndex">A 32-bit integer that represents the index in the  at which storing begins.</param>
    /// <param name="length">A 32-bit integer that represents the number of elements to copy.</param>
    public static void CopyTo(this Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
    {
        Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }

#if !NetCore
    
    /// <summary>
    ///     Copies a range of elements from an  starting at the first element and pastes them into another  starting at
    ///     the first element. The length is specified as a 64-bit integer.
    /// </summary>
    /// <param name="sourceArray">The  that contains the data to copy.</param>
    /// <param name="destinationArray">The  that receives the data.</param>
    /// <param name="length">
    ///     A 64-bit integer that represents the number of elements to copy. The integer must be between
    ///     zero and , inclusive.
    /// </param>
    public static void CopyTo(this Array sourceArray, Array destinationArray, long length)
    {
        Array.Copy(sourceArray, destinationArray, length);
    }

    /// <summary>
    ///     Copies a range of elements from an  starting at the specified source index and pastes them to another
    ///     starting at the specified destination index. The length and the indexes are specified as 64-bit integers.
    /// </summary>
    /// <param name="sourceArray">The  that contains the data to copy.</param>
    /// <param name="sourceIndex">A 64-bit integer that represents the index in the  at which copying begins.</param>
    /// <param name="destinationArray">The  that receives the data.</param>
    /// <param name="destinationIndex">A 64-bit integer that represents the index in the  at which storing begins.</param>
    /// <param name="length">
    ///     A 64-bit integer that represents the number of elements to copy. The integer must be between
    ///     zero and , inclusive.
    /// </param>
    public static void CopyTo(this Array sourceArray, long sourceIndex, Array destinationArray, long destinationIndex, long length)
    {
        Array.Copy(sourceArray, sourceIndex, destinationArray, destinationIndex, length);
    }
#endif
}