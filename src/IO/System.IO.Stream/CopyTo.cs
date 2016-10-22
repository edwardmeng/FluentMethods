using System;
using System.IO;
using FluentMethods.IO;

public static partial class Extensions
{
    /// <summary>
    /// Reads the bytes from the source stream and writes them to another stream.
    /// </summary>
    /// <param name="source">The stream to read bytes from.</param>
    /// <param name="destination">The stream to which the contents of the source stream will be copied.</param>
    public static void CopyTo(this Stream source, Stream destination)
    {
        source.CopyTo(destination, 0x14000);
    }

    /// <summary>
    /// Reads the bytes from the source stream and writes them to another stream, using a specified buffer size.
    /// </summary>
    /// <param name="source">The stream to read bytes from.</param>
    /// <param name="destination">The stream to which the contents of the source stream will be copied.</param>
    /// <param name="bufferSize">The size of the buffer. This value must be greater than zero. The default size is 81920.</param>
    public static void CopyTo(this Stream source, Stream destination, int bufferSize)
    {
        if (destination == null)
        {
            throw new ArgumentNullException(nameof(destination));
        }
        if (bufferSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bufferSize), Strings.ArgumentOutOfRange_NeedPosNum);
        }
        if (!source.CanRead && !source.CanWrite)
        {
            throw new ObjectDisposedException(nameof(source), Strings.ObjectDisposed_StreamClosed);
        }
        if (!destination.CanRead && !destination.CanWrite)
        {
            throw new ObjectDisposedException(nameof(destination), Strings.ObjectDisposed_StreamClosed);
        }
        if (!source.CanRead)
        {
            throw new NotSupportedException(Strings.NotSupported_UnreadableStream);
        }
        if (!destination.CanWrite)
        {
            throw new NotSupportedException(Strings.NotSupported_UnreadableStream);
        }
        int num;
        var buffer = new byte[bufferSize];
        while ((num = source.Read(buffer, 0, buffer.Length)) != 0)
        {
            destination.Write(buffer, 0, num);
        }
    }

}