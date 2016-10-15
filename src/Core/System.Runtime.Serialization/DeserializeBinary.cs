using System.Runtime.Serialization.Formatters.Binary;

public static partial class Extensions
{
    /// <summary>
    /// Deserialize the byte array to an object.
    /// </summary>
    /// <typeparam name="T">The type to be deserialized to.</typeparam>
    /// <param name="data">The byte array to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="System.SerializableAttribute"/>, or implement the <see cref="System.Runtime.Serialization.ISerializable"/> interface.
    /// </remarks>
    public static T DeserializeBinary<T>(this byte[] data)
    {
        return data.Deserialize<T>(new BinaryFormatter());
    }

    /// <summary>
    /// Deserialize the byte array to an object.
    /// </summary>
    /// <param name="data">The byte array to deserialize.</param>
    /// <returns>The deserialized object.</returns>
    /// <remarks>
    /// The type to be deserialized to should be decorated with the 
    /// <see cref="System.SerializableAttribute"/>, or implement the <see cref="System.Runtime.Serialization.ISerializable"/> interface.
    /// </remarks>
    public static object DeserializeBinary(this byte[] data)
    {
        return data.Deserialize(new BinaryFormatter());
    }
}
