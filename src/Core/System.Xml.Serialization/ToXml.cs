using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

public static partial class Extensions
{
    /// <summary>
    /// Serializes the object into an XML string.
    /// </summary>
    /// <remarks>
    /// The object to be serialized should be decorated with the 
    /// <see cref="SerializableAttribute"/>, or implement the <see cref="IXmlSerializable"/> interface.
    /// </remarks>
    /// <typeparam name="T">The type of the object to be serialized.</typeparam>
    /// <param name="source">The object to serialize.</param>
    /// <param name="encoding">The Encoding scheme to use when serializing the data to XML.</param>
    /// <returns>An XML encoded string representation of the source object.</returns>
    public static string ToXml<T>(this T source, Encoding encoding = null)
    {
        if (ReferenceEquals(source, null))
        {
            throw new ArgumentNullException(nameof(source));
        }

        encoding = encoding ?? Encoding.UTF8;
        using (var stream = new MemoryStream())
        {
            var serializer = new XmlSerializer(source.GetType());
            serializer.Serialize(stream, source);
            stream.Position = 0;
            return encoding.GetString(stream.ToArray());
        }
    }
}
