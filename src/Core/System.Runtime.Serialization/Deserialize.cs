using System;
using System.IO;
using System.Runtime.Serialization;

public static partial class Extensions
{
    /// <summary>
    /// Deserialize the byte array to an object through specified formatter.
    /// </summary>
    /// <typeparam name="T">The type to be deserialized to.</typeparam>
    /// <param name="data">The byte array to deserialize.</param>
    /// <param name="formatter">The formatter to use when deserializing the byte array to object</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="SerializableAttribute"/>, or implement the <see cref="ISerializable"/> interface.
    /// </remarks>
    public static T Deserialize<T>(this byte[] data, IFormatter formatter)
    {
        if (formatter == null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }
        if (data == null || data.Length == 0)
        {
            return default(T);
        }
        return (T)Deserialize(data, formatter);
    }

    /// <summary>
    /// Deserialize the byte array to an object through specified formatter.
    /// </summary>
    /// <param name="data">The byte array to deserialize.</param>
    /// <param name="formatter">The formatter to use when deserializing the byte array to object</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="SerializableAttribute"/>, or implement the <see cref="ISerializable"/> interface.
    /// </remarks>
    public static object Deserialize(this byte[] data, IFormatter formatter)
    {
        if (formatter == null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }
        if (data == null || data.Length == 0)
        {
            return null;
        }
        using (var stream = new MemoryStream(data))
        {
            var item = formatter.Deserialize(stream);
            stream.Close();
            return item;
        }
    }
}
