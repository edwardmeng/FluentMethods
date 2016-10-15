using System.Runtime.Serialization.Formatters.Binary;

public static partial class Extensions
{
    /// <summary>
    /// Serialize the object to byte array.
    /// </summary>
    /// <typeparam name="T">The type of the object to be serialized.</typeparam>
    /// <param name="obj">The object to serialize</param>
    /// <returns>A byte array representation of the source object.</returns>
    public static byte[] SerializeBinary<T>(this T obj)
    {
        return obj.Serialize(new BinaryFormatter());
    }
}
