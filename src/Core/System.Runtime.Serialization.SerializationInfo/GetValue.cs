using System;
using System.Runtime.Serialization;

public static partial class Extensions
{
    /// <summary>
    /// Retrieves a value from the <see cref="SerializationInfo"/> store.
    /// </summary>
    /// <typeparam name="T">The type of the value to retrieve. If the stored value cannot be converted to this type, the system will throw a <see cref="InvalidCastException"/>.</typeparam>
    /// <param name="info">The object that holds the serialized object data.</param>
    /// <param name="name">The name associated with the value to retrieve.</param>
    /// <returns>The object of the specified type associated with <paramref name="name"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="info"/> or <paramref name="name"/> is null.</exception>
    /// <exception cref="InvalidCastException">The value associated with <paramref name="name"/> cannot be converted to type <typeparamref name="T"/>.</exception>
    /// <exception cref="SerializationException">An element with the specified <paramref name="name"/> is not found in the current instance.</exception>
    public static T GetValue<T>(this SerializationInfo info, string name)
    {
        if (info == null) throw new ArgumentNullException(nameof(info));
        try
        {
            object value;
            if (typeof(T) == typeof(bool))
                value = info.GetBoolean(name);
            else if (typeof(T) == typeof(byte))
                value = info.GetByte(name);
            else if (typeof(T) == typeof(char))
                value = info.GetChar(name);
            else if (typeof(T) == typeof(DateTime))
                value = info.GetDateTime(name);
            else if (typeof(T) == typeof(decimal))
                value = info.GetDecimal(name);
            else if (typeof(T) == typeof(double))
                value = info.GetDouble(name);
            else if (typeof(T) == typeof(short))
                value = info.GetInt16(name);
            else if (typeof(T) == typeof(int))
                value = info.GetInt32(name);
            else if (typeof(T) == typeof(long))
                value = info.GetInt64(name);
            else if (typeof(T) == typeof(sbyte))
                value = info.GetSByte(name);
            else if (typeof(T) == typeof(float))
                value = info.GetSingle(name);
            else if (typeof(T) == typeof(string))
                value = info.GetString(name);
            else if (typeof(T) == typeof(ushort))
                value = info.GetUInt16(name);
            else if (typeof(T) == typeof(uint))
                value = info.GetUInt32(name);
            else if (typeof(T) == typeof(ulong))
                value = info.GetUInt64(name);
            else
                value = info.GetValue(name, typeof(T));
            return (T)value;
        }
        catch (InvalidCastException)
        {
            return info.GetValue(name, typeof(object)).ConvertTo<T>();
        }
    }

    /// <summary>
    /// Retrieves a value from the <see cref="SerializationInfo"/> store.
    /// </summary>
    /// <param name="info">The object that holds the serialized object data.</param>
    /// <param name="name">The name associated with the value to retrieve.</param>
    /// <returns>The object of the specified type associated with <paramref name="name"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
    /// <exception cref="SerializationException">An element with the specified <paramref name="name"/> is not found in the current instance.</exception>
    public static object GetValue(this SerializationInfo info, string name)
    {
        return info.GetValue(name, typeof(object));
    }
}
