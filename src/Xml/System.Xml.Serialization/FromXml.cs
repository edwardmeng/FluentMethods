using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public static partial class Extensions
{
    /// <summary>
    /// Deserialize XML string into an object.
    /// </summary>
    /// <typeparam name="T">The type to be deserialized to.</typeparam>
    /// <param name="source">The XML string to deserialize.</param>
    /// <param name="encoding">The Encoding scheme to use when deserializing the XML to object</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="SerializableAttribute"/>, or implement the <see cref="IXmlSerializable"/> interface.
    /// </remarks>
    public static T FromXml<T>(this string source, Encoding encoding = null)
    {
        return (T)FromXml(source, typeof(T), encoding);
    }

    /// <summary>
    /// Deserialize XML string into an object.
    /// </summary>
    /// <param name="source">The XML string to deserialize.</param>
    /// <param name="type">The type to be deserialized to.</param>
    /// <param name="encoding">The Encoding scheme to use when deserializing the XML to object</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="SerializableAttribute"/>, or implement the <see cref="IXmlSerializable"/> interface.
    /// </remarks>
    public static object FromXml(this string source, Type type, Encoding encoding = null)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        encoding = encoding ?? Encoding.UTF8;
        using (var stream = new MemoryStream(encoding.GetBytes(source)))
        {
            var serializer = new XmlSerializer(type);
            return serializer.Deserialize(stream);
        }
    }
}
