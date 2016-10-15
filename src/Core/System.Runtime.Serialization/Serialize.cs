using System;
using System.IO;
using System.Runtime.Serialization;

public static partial class Extensions
{
    /// <summary>
    /// Serialize the object to byte array through specified formatter.
    /// </summary>
    /// <typeparam name="T">The type of the object to be serialized.</typeparam>
    /// <param name="obj">The object to serialize</param>
    /// <param name="formatter">The formatter to use when serializing the object to byte array.</param>
    /// <returns>A byte array representation of the source object.</returns>
    public static byte[] Serialize<T>(this T obj, IFormatter formatter)
    {
        if (formatter == null)
        {
            throw new ArgumentNullException(nameof(formatter));
        }
        if (ReferenceEquals(obj, null))
        {
            return null;
        }
        using (var stream = new MemoryStream())
        {
            stream.Seek(0, SeekOrigin.Begin);
            formatter.Serialize(stream, obj);
            var buffer = stream.ToArray();
            stream.Close();
            return buffer;
        }
    }
}
